using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Core.DataAccess.EntityFramework
{
    public abstract class UnitOfWork<TContext> : IDisposable, IUnitOfWork<TContext> where TContext : DbContext//, new()
    {
        private readonly DbContext _context;

        protected UnitOfWork(TContext context)
        {
            _context = context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        ~UnitOfWork() =>
            Dispose();

        public void Dispose()
        {
            if (_context == null) return;
            _context.Dispose();
            GC.SuppressFinalize(this);

        }
    }
}
