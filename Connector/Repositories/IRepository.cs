using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Repositories
{
    /// <summary>Generic Repository interface</summary>
    /// <typeparam name="T"> any model class</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>Gets all.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        IEnumerable<T> GetAll();

        /// <summary>Gets the by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        T GetById(object id);

        /// <summary>Inserts the specified object.</summary>
        /// <param name="obj">The object.</param>
        void Insert(T obj);

        /// <summary>Updates the specified object.</summary>
        /// <param name="obj">The object.</param>
        void Update(T obj);

        /// <summary>Deletes the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        void Delete(object id);

        /// <summary>Saves this instance.</summary>
        void Save();
    }
}
