using PhoneBook.Data.Core.DataAccess;
using PhoneBook.Data.Entities.Concrete;
using PhoneBook.Data.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.DataAccess.Abstract
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IQueryable<Book>> GetIncludeContact(Expression<Func<Book, bool>> filter = null);

        Task<Book> GetBookIncludeContact(Expression<Func<Book, bool>> filter = null);
    }
}
