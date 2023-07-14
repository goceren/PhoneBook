using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.RabbitMQService
{
    public class HandleMethods
    {
        public Task CreateReport(CreateReportModel test)
        {
            return Task.CompletedTask;
        }

        public Task GetReports(GetReportModel test)
        {
            return Task.CompletedTask;
        }
    }



    public class GetReportModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class CreateReportModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
