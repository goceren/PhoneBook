using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data.Business.Abstract;
using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.Entities.Concrete;
using PhoneBook.Data.Entities.Dto;
using PhoneBook.Data.Entities.Dto.Book;

namespace PhoneBook.Data.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<Response<IEnumerable<BookDto>>> Get()
        {
            return await _bookService.GetList( i=> !i.Deleted);
        }

        [HttpGet("{uuid:guid}")]
        public async Task<Response<BookDto>> Get(Guid uuid)
        {
            return await _bookService.GetBookById(uuid);
        }

        [HttpPost]
        public async Task<Response<BookDto>> Post([FromBody] InsertBookDto entity)
        {
            return await _bookService.Insert(entity);

        }

        [HttpPut]
        public async Task<Response<BookDto>> Put([FromBody] UpdateBookDto entity)
        {
            return await _bookService.Update(entity);

        }

        [HttpDelete("{uuid:guid}")]
        public async Task<Response<BookDto>> Delete(Guid uuid)
        {
            return await _bookService.Delete(uuid);
        }

        [HttpPost("GetByLocationIncludeContact")]
        public async Task<Response<BookReportContentDto>> GetByLocationIncludeContact(BookStatusAndLocationFilterDto model)
        {
            return await _bookService.GetByLocationIncludeContact(model);
        }
    }
}
