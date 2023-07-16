using PhoneBook.Data.Core.DataAccess;
using PhoneBook.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.DataAccess.Abstract
{
    public interface IBookContactRepository : IGenericRepository<BookContact>
    {
    }
}
