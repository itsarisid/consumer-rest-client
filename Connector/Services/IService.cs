using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Services
{
    public interface IService<T> where T : class
    {
        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        Task<T> FindAsync(params object[] keys);

        Task<T> AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task DeleteAsync(params object[] keys);

        Task UpdateAsync(T entity);
    }
}
