using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using SplitwiseApp.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Database
{
    public class DataRepository : IDataRepository
    {
        #region Private Members
        private readonly AppDbContext _context;
        private readonly IDbConnection _connection;
        #endregion

        #region Constructor
        public DataRepository(AppDbContext context)
        {
            _context = context;
            _connection = _context.Database.GetDbConnection();
        }
        #endregion

        #region Destructor
        ~DataRepository()
        {
            _connection.Close();
            _connection.Dispose();
        }
        #endregion

        #region Public Methods
        public IQueryable<T> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return await dbSet.AddAsync(entity);
            //throw new NotImplementedException();
        }

        public EntityEntry<T> Update<T>(T entity) where T : class
        {

            throw new NotImplementedException();
        }

        public EntityEntry<T> Remove<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            var dbSet = CreateDbSet<T>();
            return await dbSet.FindAsync(id);
            //throw new NotImplementedException();
        }

        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            var dbSet = CreateDbSet<T>();
            await dbSet.AddRangeAsync(entities);
            //throw new NotImplementedException();
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }

        public void RemoveRange<T>(IEnumerable<T> entities) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }
        public Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }


        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        
       
        public IDbContextTransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }
        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Private Methods
        private DbSet<T> CreateDbSet<T>() where T : class
        {
            return _context.Set<T>();
        }
        #endregion
    }
}
