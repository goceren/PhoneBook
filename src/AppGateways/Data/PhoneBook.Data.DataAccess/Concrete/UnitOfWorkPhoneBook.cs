using PhoneBook.Data.Core.DataAccess.EntityFramework;
using PhoneBook.Data.DataAccess.Abstract;
using PhoneBook.Data.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.DataAccess.Concrete
{

    public class UnitOfWorkPhoneBook : UnitOfWork<PhoneBookContext>, IUnitOfWorkPhoneBook
    {
        private readonly PhoneBookContext _context;

        public UnitOfWorkPhoneBook(PhoneBookContext context) : base(context)
        {
            _context = context;
        }


        private IBookRepository _bookRepository;
        private IBookContactRepository _bookContactRepository;

        public IBookRepository BookRepository => _bookRepository ??= new BookRepository(_context);

        public IBookContactRepository BookContactRepository => _bookContactRepository ??= new BookContactRepository(_context);
    }
}
