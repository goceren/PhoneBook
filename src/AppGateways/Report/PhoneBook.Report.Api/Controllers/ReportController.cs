using Microsoft.AspNetCore.Mvc;
using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Core.ResponseTypes;
using PhoneBook.Report.Entities.Dto.Report;
using System;

namespace PhoneBook.Report.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<Response<IEnumerable<ReportDto>>> Get()
        {
            return await _reportService.GetList();
        }

        [HttpGet("{uuid:guid}")]
        public async Task<Response<ReportDto>> Get(Guid uuid)
        {
            return await _reportService.GetReportById(uuid);
        }

        [HttpGet("GetByRequestUuid/{uuid:guid}")]
        public async Task<Response<ReportDto>> GetByRequestUuid(Guid uuid)
        {
            return await _reportService.Get(i => i.RequestUUID == uuid);
        }

        [HttpPost]
        public async Task<Response<ReportDto>> Post([FromBody] InsertReportDto entity)
        {
            return await _reportService.Insert(entity);
        }

        [HttpPut]
        public async Task<Response<ReportDto>> Put([FromBody] UpdateReportDto entity)
        {
            return await _reportService.Update(entity);

        }

        [HttpDelete("{id:guid}")]
        public async Task<Response<ReportDto>> Delete(Guid uuid)
        {
            return await _reportService.Delete(uuid);
        }
    }
}
