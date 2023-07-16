using Microsoft.AspNetCore.Mvc;
using PhoneBook.Web.Business.Abstract;
using PhoneBook.Web.Core;
using PhoneBook.Web.Core.Enum;
using PhoneBook.Web.Entities.Dto.Report;
using PhoneBook.Web.WebApp.Infrastructures.Helper;

namespace PhoneBook.Web.WebApp.Controllers
{
    public class ReportController : Controller
    {

        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
           var model =  _reportService.GetReports();
            return View(model);
        }

        public IActionResult GetReports()
        {
            var model = _reportService.GetReports();
            return Json(model);
        }

        public IActionResult CreateReportModal()
        {
            var model = new ReportRequestDto();
            return Json(Response<string>.Success(this.RenderViewToString("CreateReportRequest", model), Enums.ResponseStatusEnum.Success.GetEnumInteger()));
        }

        public IActionResult CreateReportRequest(ReportRequestDto model)
        {
            var response = _reportService.CreateReportRequest(model);
            return Json(response);
        }

        public IActionResult Detail(Guid uuid)
        {
            var response = _reportService.GetById(uuid);
            return View(response);
        }
    }
}
