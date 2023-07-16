using PhoneBook.Web.Core;
using PhoneBook.Web.Entities.Dto.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Web.Business.Abstract
{
    public interface IBookService
    {
        Response<List<BookDto>> GetBooks();

        Response<BookDto> GetById(Guid uuid);

        Response<BookDto> Delete(Guid uuid);

        Response<BookDto> Insert(InsertBookDto model);

        Response<BookDto> Update(UpdateBookDto model);

        Response<BookDto> GetBookIncludeContact(Guid uuid);
    }
}
