using Microsoft.EntityFrameworkCore;
using PhoneBook.Report.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Report.Core.DataAccess.EntityFramework
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        protected GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> Delete(Expression<Func<TEntity, bool>> filter)
        {
            var removeData = await _dbSet.FirstOrDefaultAsync(filter);

            if (removeData != null)
            {
                _dbSet.Remove(removeData);
            }
            return removeData;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<IQueryable<TEntity>> GetList(Expression<Func<TEntity, bool>> filter)
        {
            return filter == null ? _dbSet.Where(i => true) : _dbSet.Where(filter);
        }

        public async Task<TEntity> Insert(TEntity Entity)
        {
            var insertData = await _dbSet.AddAsync(Entity);
            return insertData.Entity;
        }

        public async Task InsertList(List<TEntity> Entity)
        {
            await _dbSet.AddRangeAsync(Entity);
        }

        public async Task<TEntity> Update(TEntity Entity)
        {
            var updatedData = _dbSet.Update(Entity);

            return updatedData.Entity;
        }

        public void Dispose()
        {
        }

    }
}