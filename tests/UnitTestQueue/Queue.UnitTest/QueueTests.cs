using Newtonsoft.Json;
using ReportService.Entities.Dto.Report;
using System.Net.Http;
using System.Text;

namespace Queue.UnitTest
{
    [TestClass]
    public class QueueTests
    {
        [TestMethod]
        public void reportservice_api_unit_test()
        {

            using (var client = new HttpClient())
            {
                var model = new ReportRequestDto() { Location = "Konya" };

                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                var response = client.PostAsync("https://localhost:7001" + "/api/report/", content).GetAwaiter().GetResult();

                var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
        }


        [TestMethod]
        public void reportservice_api_unit_test_multi()
        {
            Parallel.For(0, 10, count =>
            {
                Task.Factory.StartNew(() =>
                {
                    using (var client = new HttpClient())
                    {
                        var model = new ReportRequestDto() { Location = "Konya" + count };

                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                        var response = client.PostAsync("https://localhost:7001" + "/api/report/", content).GetAwaiter().GetResult();

                        var json = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    }
                });
               
            });
            
        }

    }

}