using PhoneBook.Web.Business.Abstract;
using Microsoft.Extensions.Configuration;
using PhoneBook.Web.Core;
using PhoneBook.Web.Entities.Dto.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using PhoneBook.Web.Core.Enum;
using System.Reflection;

namespace PhoneBook.Web.Business.Concrete
{
    public class BookManager : IBookService
    {

        private readonly IConfiguration _configuration;

        public BookManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response<List<BookDto>> GetBooks()
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(connectionString + "/api/book").GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<List<BookDto>>>(json);
                    }
                    else
                    {
                        return Response<List<BookDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<List<BookDto>>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<BookDto> Delete(Guid uuid)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.DeleteAsync(connectionString + "/api/book/" + uuid).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<BookDto>>(json);
                    }
                    else
                    {
                        return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<BookDto> Insert(InsertBookDto model)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var content =  new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = httpClient.PostAsync(connectionString + "/api/book/", content).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<BookDto>>(json);
                    }
                    else
                    {
                        return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<BookDto> Update(UpdateBookDto model)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = httpClient.PutAsync(connectionString + "/api/book/", content).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<BookDto>>(json);
                    }
                    else
                    {
                        return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<BookDto> GetById(Guid uuid)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(connectionString + "/api/book/" + uuid).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<BookDto>>(json);
                    }
                    else
                    {
                        return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }

        public Response<BookDto> GetBookIncludeContact(Guid uuid)
        {
            try
            {
                var connectionString = _configuration.GetSection("API").GetSection("PhoneBook.Data.API").Value;

                using (var httpClient = new HttpClient())
                {
                    var response = httpClient.GetAsync(connectionString + "/api/book/GetBookIncludeContact/" + uuid).GetAwaiter().GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<Response<BookDto>>(json);
                    }
                    else
                    {
                        return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { response.StatusCode.ToString() });
                    }

                }
            }
            catch (Exception ex)
            {
                return Response<BookDto>.Fail(Enums.ResponseStatusEnum.Error.GetEnumInteger(), new List<string> { ex.Message });
            }
        }
    }
}
