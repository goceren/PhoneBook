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
    public interface IBookService
    {
        Task<Response<Book>> GetBookById(Guid uuid);
        Task<Response<Book>> Insert(Book entity);
        Task<Response<Book>> Update(Book entity);
        Task<Response<Book>> Delete(Guid uuid);
        Task<Response<List<Book>>> GetList(Expression<Func<Book, bool>> filter = null);
    }
}
