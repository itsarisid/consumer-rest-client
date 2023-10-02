using Connector.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>The following variable is going to hold the EmployeeDBContext instance</summary>
        private ConnectorContext _context = null;

        /// <summary>The following Variable is going to hold the DbSet Entity</summary>
        private DbSet<T> table = null;

        /// <summary>Initializes a new instance of the <see cref="Repository{T}" /> class.</summary>
        public Repository()
        {
            this._context = new ConnectorContext();
            //Whatever class name we specify while creating the instance of GenericRepository
            //That class name will be stored in the table variable
            table = _context.Set<T>();
        }

        /// <summary>Initializes a new instance of the <see cref="Repository{T}" /> class.</summary>
        /// <param name="_context">The context.</param>
        public Repository(ConnectorContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        /// <summary>This method will return all the Records from the table</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        /// <summary>based on the ID which it received as an argument</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public T GetById(object id)
        {
            return table.Find(id);
        }

        /// <summary>It will receive the object as an argument which needs to be inserted into the database</summary>
        /// <param name="obj">The object.</param>
        public void Insert(T obj)
        {
            //It will mark the Entity state as Added State
            table.Add(obj);
        }

        /// <summary>
        /// This method is going to update the record in the table
        /// It will receive the object as an argument
        /// </summary>
        /// <param name="obj"></param>
        public void Update(T obj)
        {
            //First attach the object to the table
            table.Attach(obj);
            //Then set the state of the Entity as Modified
            _context.Entry(obj).State = EntityState.Modified;
        }

        /// <summary>
        /// This method is going to remove the record from the table
        /// It will receive the primary key value as an argument whose information needs to be removed from the table
        /// </summary>
        /// <param name="id"></param>
        public void Delete(object id)
        {
            //First, fetch the record from the table
            T existing = table.Find(id);
            //This will mark the Entity State as Deleted
            table.Remove(existing);
        }

        /// <summary>
        /// This method will make the changes permanent in the database
        /// That means once we call Insert, Update, and Delete Methods, 
        /// Then we need to call the Save method to make the changes permanent in the database
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
