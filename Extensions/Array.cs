/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LundbeckConsulting.Components.Extensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Collection of elements in Array of TEntity
        /// </summary>
        /// <typeparam name="TEntity">Type to return and type of TEntity</typeparam>
        /// <param name="array">Elements to include</param>
        /// <returns>An IEnumerable containing the elements from Array</returns>
        public static IEnumerable<TEntity> ToEnumerable<TEntity>(this Array array) where TEntity : class 
        {
            ICollection<TEntity> result = new Collection<TEntity>();
            
            for(int i = 0; i < array.Length; i++)
            {
                result.Add((TEntity)array.GetValue(i));
            }

            return result;
        }

        /// <summary>
        /// List of collection elements
        /// </summary>
        /// <typeparam name="TEntity">Type of elements</typeparam>
        /// <param name="array">Collection of elements to include</param>
        /// <returns>An IList containing all elements in Array</returns>
        public static IList<TEntity> ToList<TEntity>(this Array array) where TEntity : class
        {
            IList<TEntity> result = new List<TEntity>();
            
            for(int i = 0; i < array.Length; i++)
            {
                result.Add((TEntity)array.GetValue(i));
            }

            return result;
        }

        /// <summary>
        /// Collection of array elements
        /// </summary>
        /// <typeparam name="TEntity">Type of elements</typeparam>
        /// <param name="array">Collection of elements to include</param>
        /// <returns>An ICollection containing all elements in Array</returns>
        public static ICollection<TEntity> ToCollection<TEntity>(this Array array) where TEntity : class
        {
            ICollection<TEntity> result = new Collection<TEntity>();

            for (int i = 0; i < array.Length; i++)
            {
                result.Add((TEntity)array.GetValue(i));
            }

            return result;
        }
    }
}
