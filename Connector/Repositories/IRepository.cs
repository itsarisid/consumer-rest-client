using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Repositories
{
    /// <summary>Generic Repository interface</summary>
    /// <typeparam name="T"> any model class</typeparam>
    public interface IRepository<T> where T : class
    {

        Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        IEnumerable<T> All { get; }

        // <summary>
        /// Get all queries
        /// </summary>
        /// <returns>IQueryable queries</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Find queries by predicate
        /// </summary>
        /// <param name="predicate">search predicate (LINQ)</param>
        /// <returns>IQueryable queries</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find entity by keys
        /// </summary>
        /// <param name="keys">search key</param>
        /// <returns>T entity</returns>
        Task<T> FindAsync(params object[] keys);

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        T GetById(object id);

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> AddAsync(T entity);

        /// <summary>Inserts the specified object.</summary>
        /// <param name="obj">The object.</param>
        T Insert(T obj);

        /// <summary>Updates the specified object.</summary>
        /// <param name="obj">The object.</param>
        void Update(T obj);

        /// <summary>
        /// Edit entity
        /// </summary>
        /// <param name="entity"></param>
        Task UpdateAsync(T entity);

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        void Delete(object id);

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="keys">entity keys</param>
        void Delete(params object[] keys);

        /// <summary>
        /// Remove entity from database
        /// </summary>
        Task<bool> Delete(int id);

        /// <summary>Saves this instance.</summary>
        void Save();

        Task SaveAsync();
    }
}
