using PhoneBook.Data.Core.DataAccess;
using PhoneBook.Data.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.DataAccess.Abstract
{
    public interface IUnitOfWorkPhoneBook : IUnitOfWork<PhoneBookContext>
    {
        IBookRepository BookRepository { get; }
        IBookContactRepository BookContactRepository { get; }
    }
}
