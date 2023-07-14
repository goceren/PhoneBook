using Microsoft.AspNetCore.Mvc;
using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Core.ResponseTypes;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<Response<List<Entities.Concrete.Report>>> Get()
        {
            return await _reportService.GetList();
        }

        [HttpGet("{uuid:guid}")]
        public async Task<Response<Entities.Concrete.Report>> Get(Guid uuid)
        {
            return await _reportService.GetReportById(uuid);
        }

        [HttpPost]
        public async Task<Response<Entities.Concrete.Report>> Post([FromBody] Entities.Concrete.Report entity)
        {
            return await _reportService.Insert(entity);

        }

        [HttpPut]
        public async Task<Response<Entities.Concrete.Report>> Put([FromBody] Entities.Concrete.Report entity)
        {
            return await _reportService.Update(entity);

        }

        [HttpDelete("{id:guid}")]
        public async Task<Response<Entities.Concrete.Report>> Delete(Guid uuid)
        {
            return await _reportService.Delete(uuid);
        }
    }
}
