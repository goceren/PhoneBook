using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Core.DataAccess.EntityFramework;
using PhoneBook.Data.DataAccess.Abstract;
using PhoneBook.Data.DataAccess.Context;
using PhoneBook.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.DataAccess.Concrete
{
    public class BookContactRepository : GenericRepository<BookContact>, IBookContactRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<BookContact> _dbSet;

        public BookContactRepository(PhoneBookContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<BookContact>();
        }
    }
}
