using Newtonsoft.Json;
using PhoneBook.Data.Entities.Dto;
using PhoneBook.Data.Entities.Dto.Book;
using System.Text;

namespace DataApi.UnitTest
{
    [TestClass]
    public class DataApiTests
    {
        [TestMethod]
        public void data_api_get_test()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://localhost:7118" + "/api/book/").GetAwaiter().GetResult();

                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }


        [TestMethod]
        public void data_api_post_test()
        {
            using (var client = new HttpClient())
            {
                var model = new BookDto()
                {
                    Name = "UnitTest",
                    LastName = "Method",
                    Company = "UnitTesting"
                };


                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                var response = client.PostAsync("https://localhost:7118" + "/api/book/", content).GetAwaiter().GetResult();
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }


        [TestMethod]
        public void data_api_GetByLocationIncludeContact_test()
        {
            using (var client = new HttpClient())
            {
                var model = new BookStatusAndLocationFilterDto()
                {
                    Location = "Konya",
                };

                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                var response = client.PostAsync("https://localhost:7118" + "/api/book/GetByLocationIncludeContact", content).GetAwaiter().GetResult();
                //GetByLocationIncludeContact
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}