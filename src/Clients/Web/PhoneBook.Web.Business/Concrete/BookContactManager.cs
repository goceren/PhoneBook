using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PhoneBook.Web.Business.Abstract;
using PhoneBook.Web.Core;
using PhoneBook.Web.Core.Enum;
using PhoneBook.Web.Entities.Dto.BookContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Web.Business.Concrete
{
    public class BookContactManager : IBookContactService
    {

        private readonly IConfiguration _configuration;

        public BookContactManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response<BookContactDto> Delete(Guid uuid)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.DeleteAsync(connectionString + "/api/bookContact/" + uuid).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<BookContactDto>>(json);
                    }
                    else
                    {
                        return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }
                }
            }
            catch (Exception ex)
            {
                return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<List<BookContactDto>> GetBookContacts()
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(connectionString + "/api/bookContact").GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<List<BookContactDto>>>(json);
                    }
                    else
                    {
                        return Response<List<BookContactDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<List<BookContactDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<BookContactDto> GetById(Guid uuid)
        {

            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(connectionString + "/api/bookContact/" + uuid).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<BookContactDto>>(json);
                    }
                    else
                    {
                        return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<List<BookContactDto>> GetListByBook(Guid uuid)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(connectionString + "/api/bookContact/GetListByBook/" + uuid).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<List<BookContactDto>>>(json);
                    }
                    else
                    {
                        return Response<List<BookContactDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<List<BookContactDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<BookContactDto> Insert(InsertBookContactDto model)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = httpClient.PostAsync(connectionString + "/api/bookContact/", content).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<BookContactDto>>(json);
                    }
                    else
                    {
                        return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<BookContactDto> Update(UpdateBookContactDto model)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = httpClient.PutAsync(connectionString + "/api/bookContact/", content).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<BookContactDto>>(json);
                    }
                    else
                    {
                        return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }
    }
}
