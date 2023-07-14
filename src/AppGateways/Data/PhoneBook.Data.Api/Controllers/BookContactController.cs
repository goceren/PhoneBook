using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data.Business.Abstract;
using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.Entities.Concrete;

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
        public async Task<Response<List<BookContact>>> Get()
        {
            return await _bookContactService.GetList();
        }

        [HttpGet("{uuid:guid}")]
        public async Task<Response<BookContact>> Get(Guid uuid)
        {
            return await _bookContactService.GetBookContactById(uuid);
        }

        [HttpPost]
        public async Task<Response<BookContact>> Post([FromBody] BookContact entity)
        {
            return await _bookContactService.Insert(entity);

        }

        [HttpPut]
        public async Task<Response<BookContact>> Put([FromBody] BookContact entity)
        {
            return await _bookContactService.Update(entity);

        }

        [HttpDelete("{id:guid}")]
        public async Task<Response<BookContact>> Delete(Guid uuid)
        {
            return await _bookContactService.Delete(uuid);
        }
    }
}
