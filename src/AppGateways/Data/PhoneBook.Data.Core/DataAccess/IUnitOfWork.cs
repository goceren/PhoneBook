using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Core.DataAccess
{
    public interface IUnitOfWork<TContext> where TContext : DbContext, IDisposable
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
