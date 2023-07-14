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
    public class GenericRepository<TEntity, TContext> : IEntityRepository<TEntity>
         where TEntity : class, BaseEntity, new()
        where TContext : DbContext, new()
    {
        public async Task<TEntity> Delete(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                var removeData = await context.Set<TEntity>().FirstOrDefaultAsync(filter);

                if (removeData != null)
                {
                    context.Set<TEntity>().Remove(removeData);
                    context.SaveChanges();
                }

                return removeData;
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task<TEntity> Insert(TEntity Entity)
        {
            using (var context = new TContext())
            {
                var insertData = await context.Set<TEntity>().AddAsync(Entity);
                await context.SaveChangesAsync();

                return insertData.Entity;
            }
        }

        public async Task InsertList(List<TEntity> Entity)
        {
            using (var context = new TContext())
            {
                await context.Set<TEntity>().AddRangeAsync(Entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Update(TEntity Entity)
        {
            using (var context = new TContext())
            {
                var updatedData = context.Set<TEntity>().Update(Entity);
                await context.SaveChangesAsync();

                return updatedData.Entity;
            }

        }

        public void Dispose()
        {
        }
    }
}