using Connector.Entities;
using Connector.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Connector.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>The following variable is going to hold the EmployeeDBContext instance</summary>
        private DatabaseContext _context = null;

        /// <summary>The following Variable is going to hold the DbSet Entity</summary>
        private DbSet<T> _dbSet = null;

        /// <summary>Initializes a new instance of the <see cref="Repository{T}" /> class.</summary>
        public Repository()
        {
            this._context = new DatabaseContext();
            //Whatever class name we specify while creating the instance of GenericRepository
            //That class name will be stored in the table variable
            _dbSet = _context.Set<T>();
        }

        /// <summary>Initializes a new instance of the <see cref="Repository{T}" /> class.</summary>
        /// <param name="_context">The context.</param>
        public Repository(DatabaseContext _context)
        {
            this._context = _context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T> FirstAsync(Expression<Func<T, bool>> predicate) => await _dbSet.FirstAsync(predicate);

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate) => await _dbSet.FirstOrDefaultAsync(predicate);

        /// <summary>This method will return all the Records from the table</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public virtual IEnumerable<T> All => _dbSet.ToList();

        /// <summary>based on the ID which it received as an argument</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public virtual T GetById(object id)=>_dbSet.Find(id);

        public virtual IQueryable<T> GetAll() => _dbSet.AsNoTracking();

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);

        public async Task<T> FindAsync(params object[] keys) => await _dbSet.FindAsync(keys);

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        /// <summary>It will receive the object as an argument which needs to be inserted into the database</summary>
        /// <param name="obj">The object.</param>
        public virtual T Insert(T obj)
        {
            //It will mark the Entity state as Added State
            _dbSet.Add(obj);
            return obj;
        }

        /// <summary>
        /// This method is going to update the record in the table
        /// It will receive the object as an argument
        /// </summary>
        /// <param name="obj"></param>
        public virtual void Update(T obj)
        {
            //First attach the object to the table
            _dbSet.Attach(obj);
            //Then set the state of the Entity as Modified
            _context.Entry(obj).State = EntityState.Modified;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            //var existing = await _dbSet.FindAsync(entity.Id);
            //if (existing != null)
            //{
            //    existing.ModifiedDate = DateTime.UtcNow;
            //    _context.Entry(existing).CurrentValues.SetValues(entity);
            //    _context.Entry(existing).Property("AddedDate").IsModified = false;
            //}

            throw new NotImplementedException();
        }

        /// <summary>
        /// This method is going to remove the record from the table
        /// It will receive the primary key value as an argument whose information needs to be removed from the table
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(object id)
        {
            //First, fetch the record from the table
            T existing = _dbSet.Find(id);
            //This will mark the Entity State as Deleted
            _dbSet.Remove(existing);
        }

        /// <summary>
        /// The Delete method deletes an entity by its identifier.
        /// </summary>
        /// <param name="keys"></param>
        public virtual void Delete(params object[] keys)
        {
            var entity = _dbSet.Find(keys);
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// The Delete method deletes an entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// The Delete method deletes an entity by its identifier.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null) return false;

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// This method will make the changes permanent in the database
        /// That means once we call Insert, Update, and Delete Methods, 
        /// Then we need to call the Save method to make the changes permanent in the database
        /// </summary>
        public virtual  void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// This method will make the changes permanent in the database
        /// That means once we call Insert, Update, and Delete Methods, 
        /// Then we need to call the Save method to make the changes permanent in the database
        /// </summary>
        public virtual async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        
    }
}
