using Newtonsoft.Json;
using PhoneBook.Report.Entities.Dto.Report;
using System.Text;

namespace ReportApi.UnitTest
{
    [TestClass]
    public class ReportApiTests
    {
        [TestMethod]
        public void report_api_get_test()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://localhost:7112" + "/api/report/").GetAwaiter().GetResult();

                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }


        [TestMethod]
        public void report_api_post_test()
        {
            using (var client = new HttpClient())
            {
                var model = new ReportDto()
                {
                    Location = "UNITTEST",
                    PersonCount = 111,
                    PersonPhoneCount = 111,
                    RequestDate = DateTime.Now,
                    Status = PhoneBook.Report.Core.Enum.Enums.ReportStatusEnum.Processing,
                    RequestUUID = Guid.NewGuid(),
                };


                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                var response = client.PostAsync("https://localhost:7112" + "/api/report/", content).GetAwaiter().GetResult();
                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }
    }
}