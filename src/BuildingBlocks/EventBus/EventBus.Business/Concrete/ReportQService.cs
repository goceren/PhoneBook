using EventBus.Business.Abstract;
using EventBus.Core.Dto;
using EventBus.Core.Enum;
using EventBus.Core.Models;
using EventBus.Core.ResponseTypes;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventBus.Core.Enum.Enums;

namespace EventBus.Business.Concrete
{
    public class ReportQService : IReportQService
    {
        private readonly IConfiguration _configuration;

        public ReportQService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Response<ReportDto>> CreateReport(CreateReportModel model)
        {

            try
            {
                var reportApiUrl = _configuration.GetSection("API").GetSection("PhoneBook.Report.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var reportData = new ReportDto()
                    {
                        RequestUUID = model.RequestUUID,
                        Location = model.Location,
                        Status = ReportStatusEnum.Processing,
                        PersonCount = 0,
                        PersonPhoneCount = 0,
                        RequestDate = DateTime.Now,
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(reportData), Encoding.UTF8, "application/json");

                    var insertReportResponse = httpClient.PostAsync(reportApiUrl + "/api/Report", content).Result;

                    var insertReportResponseJson = await insertReportResponse.Content.ReadAsStringAsync();

                    var reportResult = JsonConvert.DeserializeObject<Response<ReportDto>>(insertReportResponseJson);

                    return reportResult;

                }


            }
            catch (Exception ex)
            {
                return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string>() { ex.Message });

            }

        }

        public async Task<Response<ReportDto>> CompleteReport(CreateReportModel model)
        {
            try
            {
                var reportApiUrl = _configuration.GetSection("API").GetSection("PhoneBook.Report.API").Value;
                var dataApiUrl = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    var response = httpClient.PostAsync(dataApiUrl + "/api/Book/GetByLocationIncludeContact", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        var data = JsonConvert.DeserializeObject<Response<BookReportContentDto>>(json);

                        if (data != null && data.IsSuccessful)
                        {
                            


                            var controlReport = httpClient.GetAsync(reportApiUrl + "/api/Report/GetByRequestUuid/" + model.RequestUUID).Result;
                            var controlReportJson = await controlReport.Content.ReadAsStringAsync();
                            var controlReportResult = JsonConvert.DeserializeObject<Response<ReportDto>>(controlReportJson);

                            if (controlReportResult.IsSuccessful)
                            {
                                var reportData = new ReportDto()
                                {
                                    RequestUUID= controlReportResult.Data.RequestUUID,
                                    UUID = controlReportResult.Data.UUID,
                                    Location = data.Data.Location,
                                    Status = ReportStatusEnum.Completed,
                                    PersonCount = data.Data.Books.Count(),
                                    PersonPhoneCount = data.Data.Books.SelectMany(i => i.BookContacts).Where(i => i.Type == Enums.ContactTypeEnum.Phone).Count(),
                                    RequestDate = controlReportResult.Data.RequestDate,
                                };
                                var reportContent = new StringContent(JsonConvert.SerializeObject(reportData), Encoding.UTF8, "application/json");
                                var insertReportResponse = httpClient.PutAsync(reportApiUrl + "/api/Report", reportContent).Result;
                                var insertReportResponseJson = await insertReportResponse.Content.ReadAsStringAsync();
                                var reportResult = JsonConvert.DeserializeObject<Response<ReportDto>>(insertReportResponseJson);

                                return reportResult;
                            }

                            else
                            {
                                return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.NoData.GetEnumInteger(), new List<string>() { "Veri Bulunamadı" });

                            }
                        }
                        else
                        {
                            return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.NoData.GetEnumInteger(), new List<string>() { "Veri Bulunamadı" });
                        }
                    }
                    else
                    {
                        return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string>() { response.StatusCode.ToString() });
                    }
                }

            }
            catch (Exception ex)
            {
                return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string>() { ex.Message });

            }

        }
    }
}
