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
    public class EfBookContactDal : GenericRepository<BookContact, PhoneBookContext>, IBookContactDal
    {
    }
}
