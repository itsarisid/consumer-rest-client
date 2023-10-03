using Connector.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Services
{
    public class Service<T>(IRepository<T> _repository) : IService<T> where T : class
    {
        public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> predicate) => await _repository.FirstAsync(predicate);

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await _repository.FirstOrDefaultAsync(predicate);

        public virtual IQueryable<T> GetAll() => _repository.GetAll();

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => _repository.FindBy(predicate);

        public async Task<T> FindAsync(params object[] keys) => await _repository.FindAsync(keys); 

        public virtual async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _repository.Delete(entity);
            await _repository.SaveAsync();
        }

        public virtual async Task DeleteAsync(params object[] keys)
        {
            var entity = await _repository.FindAsync(keys);
            _repository.Delete(entity);
            await _repository.SaveAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            await _repository.SaveAsync();
        }
    }
}
