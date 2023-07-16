using EventBus.Business.Abstract;
using EventBus.Core.Dto;
using EventBus.Core.Models;
using EventBus.Core.ResponseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EventBus.Core.Enum.Enums;

namespace EventBus.RabbitMQService
{
    public class HandleMethods
    {
        private readonly IReportQService _reportQService;
        private int DelayTime = 10;
        public HandleMethods(IReportQService reportQService, int delayTime = 10)
        {
            _reportQService = reportQService;
            DelayTime = delayTime;
        }

        public async Task<Response<ReportDto>> CreateReport(CreateReportModel reportRequestModel)
        {

            var initReportToQueue = await _reportQService.CreateReport(reportRequestModel);

            Thread.Sleep(1000 * DelayTime);

            if (initReportToQueue.IsSuccessful)
            {
                return await _reportQService.CompleteReport(reportRequestModel);
            }
            else
            {
                return initReportToQueue;
            }
        }
    }
 
}
