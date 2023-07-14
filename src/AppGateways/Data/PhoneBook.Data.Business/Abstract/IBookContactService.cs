using PhoneBook.Data.Core.ResponseTypes;
using PhoneBook.Data.Entities.Concrete;
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
        Task<Response<BookContact>> GetBookContactById(Guid uuid);
        Task<Response<BookContact>> Insert(BookContact entity);
        Task<Response<BookContact>> Update(BookContact entity);
        Task<Response<BookContact>> Delete(Guid uuid);
        Task<Response<List<BookContact>>> GetList(Expression<Func<BookContact, bool>> filter = null);
    }
}
