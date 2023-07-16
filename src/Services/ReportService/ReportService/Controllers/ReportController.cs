using Microsoft.AspNetCore.Mvc;
using ReportService.Business.Abstract;
using ReportService.Core.Enum;
using ReportService.Core.ResponseTypes;
using ReportService.Entities.Dto;
using ReportService.Entities.Dto.Report;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportQueueService _reportQueueService;

        public ReportController(IReportQueueService reportQueueService)
        {
            _reportQueueService = reportQueueService;
        }

        [HttpPost]
        public async Task<Response<ReportRequestDto>> Post([FromBody] ReportRequestDto entity)
        {
            return await _reportQueueService.CreateReportRequest(entity);
        }
    }
}
