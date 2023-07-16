using PhoneBook.Web.Core;
using PhoneBook.Web.Entities.Dto.BookContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Web.Business.Abstract
{
    public interface IBookContactService
    {
        Response<List<BookContactDto>> GetBookContacts();

        Response<List<BookContactDto>> GetListByBook(Guid uuid);

        Response<BookContactDto> GetById(Guid uuid);

        Response<BookContactDto> Delete(Guid uuid);

        Response<BookContactDto> Insert(InsertBookContactDto model);

        Response<BookContactDto> Update(UpdateBookContactDto model);
    }
}
