using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data.Business.Abstract;
using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.Entities.Concrete;

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
        public async Task<Response<List<Book>>> Get()
        {
            return await _bookService.GetList();
        }

        [HttpGet("{uuid:guid}")]
        public async Task<Response<Book>> Get(Guid uuid)
        {
            return await _bookService.GetBookById(uuid);
        }

        [HttpPost]
        public async Task<Response<Book>> Post([FromBody] Book entity)
        {
            return await _bookService.Insert(entity);

        }

        [HttpPut]
        public async Task<Response<Book>> Put([FromBody] Book entity)
        {
            return await _bookService.Update(entity);

        }

        [HttpDelete("{id:guid}")]
        public async Task<Response<Book>> Delete(Guid uuid)
        {
            return await _bookService.Delete(uuid);
        }
    }
}
