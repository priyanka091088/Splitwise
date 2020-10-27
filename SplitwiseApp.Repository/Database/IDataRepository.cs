using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SplitwiseApp.Repository.Database
{
    public interface IDataRepository
    {
        /// This return first element that definately matches with the provided expression asynchronously
        /// <typeparam name="T">Model class to get the data</typeparam>
        /// <param name="predicate">Expression to retrieve data</param>
        /// <returns>First element that matches all the condition</returns>
        Task<T> FirstAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// Filters data based on predicate.
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>IQueryable containing filtered elements.</returns>
        IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// Retrieves all the data.
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <returns>List of all the elements.</returns>
        IQueryable<T> GetAll<T>() where T : class;

        /// Adds entity to the database asynchronously
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to add.</param>
        Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class;

        /// Adds the given collection of entities to the database asynchronously
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to add.</param>
        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;

        /// Updates entity in the database.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to update.</param>
        EntityEntry<T> Update<T>(T entity) where T : class;


        /// <summary>
        /// Updates the given collection of entities in the database.
        /// </summary>
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entities to update.</param>
        void UpdateRange<T>(IEnumerable<T> entities) where T : class;

        /// Remove entity from the database.
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entity">Entity to remove.</param>
        EntityEntry<T> Remove<T>(T entity) where T : class;

        /// Remove the given collection of entities from the database.
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="entities">Entities to remove.</param>
        void RemoveRange<T>(IEnumerable<T> entities) where T : class;

        /// Method to begin database transaction.
        IDbContextTransaction BeginTransaction();

        /// Method to commit database transaction.
        void CommitTransaction();

        /// Method to rollback database transaction.
        void RollbackTransaction();

        /// Method to find data from database using its id asynchronously.
        /// <typeparam name="T">Model class to create DbSet.</typeparam>
        /// <param name="id">Id of data i.e primary key.</param>
        Task<T> GetByIdAsync<T>(int id) where T : class;

        /// Calls SaveChanges on the db context.
        Task<int> SaveChangesAsync();

        /// This return first element that definately matches with the provided expression
        /// otherwise return null if no element found asynchronously
        /// <typeparam name="T">Model class to get the data</typeparam>
        /// <param name="predicate">Expression to retrieve data</param>
        /// <returns>First element that matches all the condition otherwise null</returns>
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// Method to get entity using SingleOrDefaultAsync
        /// <typeparam name="T">Model class to fetch DbSet.</typeparam>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>Filtered elements</returns>
        Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> predicate) where T : class;

    }
}
