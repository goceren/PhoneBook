using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.Entities.Concrete;
using PhoneBook.Data.Entities.Dto.BookContact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Business.Abstract
{
    public interface IBookContactService
    {
        Task<Response<BookContactDto>> GetBookContactById(Guid uuid);
        Task<Response<BookContactDto>> Insert(InsertBookContactDto entity);
        Task<Response<BookContactDto>> Update(UpdateBookContactDto entity);
        Task<Response<BookContactDto>> Delete(Guid uuid);
        Task<Response<IEnumerable<BookContactDto>>> GetList(Expression<Func<BookContact, bool>> filter = null);
    }
}
