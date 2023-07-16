using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PhoneBook.Web.Business.Abstract;
using PhoneBook.Web.Core;
using PhoneBook.Web.Core.Enum;
using PhoneBook.Web.Entities.Dto.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Web.Business.Concrete
{
    public class ReportManager : IReportService
    {

        private readonly IConfiguration _configuration;

        public ReportManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response<List<ReportDto>> GetReports()
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Report.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(connectionString + "/api/report").GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<List<ReportDto>>>(json);
                    }
                    else
                    {
                        return Response<List<ReportDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<List<ReportDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<ReportDto> GetById(Guid uuid)
        {

            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Report.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(connectionString + "/api/report/" + uuid).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<ReportDto>>(json);
                    }
                    else
                    {
                        return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<ReportDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<ReportRequestDto> CreateReportRequest(ReportRequestDto model)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("ReportService").Value;

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                    var response = httpClient.PostAsync(connectionString + "/api/report/", content).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<ReportRequestDto>>(json);
                    }
                    else
                    {
                        return Response<ReportRequestDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<ReportRequestDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }
    }
}
