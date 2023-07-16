using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Core.DataAccess.EntityFramework;
using PhoneBook.Data.DataAccess.Abstract;
using PhoneBook.Data.DataAccess.Context;
using PhoneBook.Data.Entities.Concrete;
using PhoneBook.Data.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.DataAccess.Concrete
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Book> _dbSet;

        public BookRepository(PhoneBookContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Book>();
        }

        public async Task<IQueryable<Book>> GetIncludeContact(Expression<Func<Book, bool>> filter = null)
        {
            return _dbSet.Where(filter).Include(i => i.BookContacts.Where(i => !i.Deleted));
        }

        public async Task<Book> GetBookIncludeContact(Expression<Func<Book, bool>> filter = null)
        {
            return _dbSet.Where(filter).Include(i => i.BookContacts.Where(i => !i.Deleted)).FirstOrDefault();
        }
    }
}
