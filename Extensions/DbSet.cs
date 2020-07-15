/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LundbeckConsulting.Components.Extensions
{
    public static class DbSetExtensions
    {
        /// <summary>
        /// Runs an async Where query against the defined DbSet
        /// </summary>
        /// <typeparam name="TEntity">Type of object to query</typeparam>
        /// <param name="dbSet">Data to query</param>
        /// <param name="predicate">Predicate to use in query</param>
        public static async Task<IEnumerable<TEntity>> WhereAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDataEntityBase
        {
            var result = await dbSet.Where(predicate).ToListAsync();

            return result;
        }

        /// <summary>
        /// Returns result of query or Default if query don't result in any elements
        /// </summary>
        /// <typeparam name="TEntity">Type of object in the collection</typeparam>
        /// <param name="dbSet">DbSet to query</param>
        /// <param name="predicate">Query to run against DbSet</param>
        /// <returns>The returned elements from the query or Default if no rows selected</returns>
        public static async Task<IEnumerable<TEntity>> WhereOrDefaultAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDataEntityBase
        {
            var tmp = await dbSet.WhereAsync(predicate);
            IEnumerable<TEntity> result = tmp.Count() > 0 ? tmp : default;

            return result;
        }

        /// <summary>
        /// Runs an async Single query against the defined DbSet
        /// </summary>
        /// <typeparam name="TEntity">Type of object to query</typeparam>
        /// <param name="dbSet">Data to query</param>
        /// <param name="predicate">Predicate to use in query</param>
        public static async Task<TEntity> SingleAsync<TEntity>(this DbSet<TEntity> dbSet, Expression<Func<TEntity, bool>> predicate) where TEntity : class, IDataEntityBase
        {
            var tmp = await dbSet.WhereAsync(predicate);

            return tmp.ElementAt(0);
        }

        /// <summary>
        /// Async creates a list of the DbSet
        /// </summary>
        /// <typeparam name="TEntity">Type of object to list</typeparam>
        /// <param name="dbSet">Data to list</param>
        /// <returns>IEnumerable with TEntity objects from DbSet</returns>
        public static async Task<IEnumerable<TEntity>> ListAsync<TEntity>(this DbSet<TEntity> dbSet) where TEntity : class, IDataEntityBase => await dbSet.ToListAsync();

        /// <summary>
        /// Returns the first element of DbSet
        /// </summary>
        /// <typeparam name="TEntity">Type of objects in DbSet</typeparam>
        /// <param name="dbSet">Elements to process</param>
        /// <returns>The first element of the DbSet. If the DbSet has no rows Default is returned/returns>
        public static async Task<TEntity> FirstElementAsync<TEntity>(this DbSet<TEntity> dbSet) where TEntity : class, IDataEntityBase
        {
            IEnumerable<TEntity> result = await dbSet.AllAsync();

            return result.FirstOrDefault();
        }

        /// <summary>
        /// Queries DbSet for all elements
        /// </summary>
        /// <typeparam name="TEntity">Type of object in DbSet</typeparam>
        /// <param name="dbSet">The DbSet to query</param>
        /// <returns>All elements in DbSet</returns>
        public static async Task<IEnumerable<TEntity>> AllAsync<TEntity>(this DbSet<TEntity> dbSet) where TEntity : class, IDataEntityBase => await dbSet.ToListAsync();
    }
}
