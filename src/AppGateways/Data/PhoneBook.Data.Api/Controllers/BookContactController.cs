using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data.Business.Abstract;
using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.Entities.Concrete;
using PhoneBook.Data.Entities.Dto.BookContact;

namespace PhoneBook.Data.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookContactController : ControllerBase
    {
        private readonly IBookContactService _bookContactService;

        public BookContactController(IBookContactService bookContactService)
        {
            _bookContactService = bookContactService;
        }

        [HttpGet]
        public async Task<Response<IEnumerable<BookContactDto>>> Get()
        {
            return await _bookContactService.GetList(i => !i.Deleted);
        }

        [HttpGet("{uuid:guid}")]
        public async Task<Response<BookContactDto>> Get(Guid uuid)
        {
            return await _bookContactService.GetBookContactById(uuid);
        }

        [HttpPost]
        public async Task<Response<BookContactDto>> Post([FromBody] InsertBookContactDto entity)
        {
            return await _bookContactService.Insert(entity);

        }

        [HttpPut]
        public async Task<Response<BookContactDto>> Put([FromBody] UpdateBookContactDto entity)
        {
            return await _bookContactService.Update(entity);

        }

        [HttpDelete("{uuid:guid}")]
        public async Task<Response<BookContactDto>> Delete(Guid uuid)
        {
            return await _bookContactService.Delete(uuid);
        }

        [HttpGet("GetListByBook/{uuid:guid}")]
        public async Task<Response<IEnumerable<BookContactDto>>> GetListByBook(Guid uuid)
        {
            return await _bookContactService.GetList(i => i.BookUUID == uuid && !i.Deleted);
        }
    }
}
