using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Web.Business.Abstract;
using PhoneBook.Web.Core;
using PhoneBook.Web.Core.Enum;
using PhoneBook.Web.Entities.Dto.Book;
using PhoneBook.Web.WebApp.Infrastructures.Helper;
using System;

namespace PhoneBook.Web.WebApp.Controllers
{
    public class BookController : Controller
    {

        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(ILogger<BookController> logger, IBookService bookService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(Guid bookUuid)
        {
            var result = _bookService.GetBookIncludeContact(bookUuid);
            return View(result);
        }

        public ActionResult InsertModal()
        {
            var model = new InsertBookDto();
            return Json(Response<string>.Success(this.RenderViewToString("Insert", model), Enums.ResponseStatusEnum.Success.GetEnumInteger()));
        }

        public ActionResult Insert(InsertBookDto model)
        {
            var response = _bookService.Insert(model);
            return Json(response);
        }

        public ActionResult EditModal(Guid uuid)
        {
            var controlData = _bookService.GetById(uuid);

            if (controlData.IsSuccessful)
            {
                var model = _mapper.Map<UpdateBookDto>(controlData.Data);
                return Json(Response<string>.Success(this.RenderViewToString("Edit", model), Enums.ResponseStatusEnum.Success.GetEnumInteger()));
            }
            else
            {
                return Json(Response<string>.Fail(Enums.ResponseStatusEnum.Success.GetEnumInteger(), new List<string> { "Not Found" }));
            }
        }

        public ActionResult Edit(UpdateBookDto model)
        {
            var response = _bookService.Update(model);
            return Json(response);
        }

        public ActionResult GetBooks()
        {
            var response = _bookService.GetBooks();
            return Json(response);
        }

        public ActionResult Delete(Guid uuid)
        {
            var response = _bookService.Delete(uuid);
            return Json(response);
        }

    }
}
