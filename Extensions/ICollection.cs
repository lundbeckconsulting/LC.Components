/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LundbeckConsulting.Components.Extensions
{
    public static class ICollectionExtensions
    {
        /// <summary>
        /// Replaces all elements in collection with items
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="coll">Collection to process</param>
        /// <param name="items">Elements to replace content with</param>
        /// <returns>Collection with items</returns>
        public static ICollection<TEntity> Replace<TEntity>(this ICollection<TEntity> coll, IEnumerable<TEntity> items)
        {
            coll.Clear();
            coll.AddRange(items);

            return coll;
        }

        /// <summary>
        /// Adds the specified items to a ICollection
        /// </summary>
        /// <typeparam name="TEntity">Type to handle</typeparam>
        /// <param name="coll">Collection to add to</param>
        /// <param name="items">Items to add to the collection</param>
        /// <returns>The collection with the specified items added</returns>
        public static ICollection<TEntity> AddRange<TEntity>(this ICollection<TEntity> coll, IEnumerable<TEntity> items)
        {
            foreach (TEntity item in items)
            {
                coll.Add(item);
            }

            return coll;
        }

        /// <summary>
        /// Deletes elements with index between start and end
        /// </summary>
        /// <typeparam name="TEntity">Type of object in collection</typeparam>
        /// <param name="coll">Elements to process</param>
        /// <param name="start">Start index</param>
        /// <param name="end">End index</param>
        /// <returns>A collection with remaining elements</returns>
        public static ICollection<TEntity> RemoveRange<TEntity>(this ICollection<TEntity> coll, int start, int end)
        {
            ICollection<TEntity> result = new Collection<TEntity>();

            for (int i = 0; i < coll.Count; i++)
            {
                if (i < start || i > end)
                {
                    result.Add(coll.ElementAt(i));
                }
            }

            return result;
        }

        /// <summary>
        /// Removes all items in Items from the collection
        /// </summary>
        /// <typeparam name="TEntity">Type of object in collection</typeparam>
        /// <param name="coll">Collection of items to remove from</param>
        /// <param name="items">Collection of items to remove</param>
        /// <returns>Collection without the objects in items</returns>
        public static ICollection<TEntity> Remove<TEntity>(this ICollection<TEntity> coll, IEnumerable<TEntity> items) where TEntity : class, IDataEntityBase
        {
            ICollection<TEntity> result = new Collection<TEntity>();

            foreach (TEntity item in items)
            {
                if (!coll.Exists(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        /// <summary>
        /// Determines if the item exists in the collection
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="coll">Collection to process</param>
        /// <param name="item">Item to examine</param>
        /// <returns>True if item exists in collection</returns>
        public static bool Exists<TEntity>(this ICollection<TEntity> coll, TEntity item) where TEntity : class, IDataEntityBase => coll.Where(itm => itm.Id == item.Id).Count() > 0;
    }
}
