using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Core.DataAccess
{
    public interface IGenericRepository<T> : IDisposable
    {

        Task<T> Insert(T Entity);
        Task InsertList(List<T> Entity);
        Task<T> Update(T Entity);
        Task<T> Delete(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter = null);
        Task<IQueryable<T>> GetList(Expression<Func<T, bool>> filter = null);


    }
}
