using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Web.Business.Abstract;
using PhoneBook.Web.Core;
using PhoneBook.Web.Core.Enum;
using PhoneBook.Web.Entities.Dto.Book;
using PhoneBook.Web.Entities.Dto.BookContact;
using PhoneBook.Web.WebApp.Infrastructures.Helper;
using System;

namespace PhoneBook.Web.WebApp.Controllers
{
    public class BookContactController : Controller
    {

        private readonly ILogger<BookContactController> _logger;
        private readonly IBookService _bookService;
        private readonly IBookContactService _bookContactService;
        private readonly IMapper _mapper;
        public BookContactController(ILogger<BookContactController> logger, IBookService bookService, IBookContactService bookContactService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _bookContactService = bookContactService;
            _mapper = mapper;
        }

        public IActionResult Index(Guid bookUuid)
        {
            var book = _bookService.GetById(bookUuid);
            return View(book.Data);
        }

        public IActionResult GetListByBook(Guid bookUuid)
        {
            var controlData = _bookContactService.GetListByBook(bookUuid);

            if (controlData.IsSuccessful)
            {
                return Json(controlData);
            }
            else
            {
                return Json(Response<BookContactDto>.Fail(Enums.ResponseStatusEnum.Success.GetEnumInteger(), new List<string> { "Not Found" }));
            }
        }

        public ActionResult InsertModal(Guid bookUUID)
        {
            var model = new InsertBookContactDto() { BookUUID = bookUUID };
            return Json(Response<string>.Success(this.RenderViewToString("Insert", model), Enums.ResponseStatusEnum.Success.GetEnumInteger()));
        }

        public ActionResult Insert(InsertBookContactDto model)
        {
            var response = _bookContactService.Insert(model);
            return Json(response);
        }

        public ActionResult EditModal(Guid uuid)
        {
            var controlData = _bookContactService.GetById(uuid);

            if (controlData.IsSuccessful)
            {
                var model = _mapper.Map<UpdateBookContactDto>(controlData.Data);
                return Json(Response<string>.Success(this.RenderViewToString("Edit", model), Enums.ResponseStatusEnum.Success.GetEnumInteger()));
            }
            else
            {
                return Json(Response<string>.Fail(Enums.ResponseStatusEnum.Success.GetEnumInteger(), new List<string> { "Not Found" }));
            }
        }

        public ActionResult Edit(UpdateBookContactDto model)
        {
            var response = _bookContactService.Update(model);
            return Json(response);
        }

        public ActionResult GetBookContacts()
        {
            var response = _bookContactService.GetBookContacts();
            return Json(response);
        }

        public ActionResult Delete(Guid uuid)
        {
            var response = _bookContactService.Delete(uuid);
            return Json(response);
        }

    }
}
