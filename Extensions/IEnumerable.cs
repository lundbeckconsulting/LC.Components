﻿/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Extensions.Model;
using LundbeckConsulting.Components.Repos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;

namespace LundbeckConsulting.Components.Extensions
{
    public static class IEnumerableExtensions
    {
        private readonly static IExtensionRepo _repo = new ExtensionRepo();

        /// <summary>
        /// Returns elements with index number between Start and End
        /// </summary>
        /// <typeparam name="TEntity">Type of object used to populate result</typeparam>
        /// <param name="from">Must be greater than zero</param>
        /// <param name="to">Top index to include</param>
        /// <returns>Elements that have index number greater or equal to From number and smaller or equal the To number</returns>
        public static IEnumerable<TEntity> Between<TEntity>(this IEnumerable<TEntity> coll, int from, int? to) where TEntity : class => _repo.CollectionBetween<TEntity>(coll, from, to);

        /// <summary>
        /// Casts IEnumerable to ICollection
        /// </summary>
        /// <typeparam name="TEntity">Type to handle</typeparam>
        /// <param name="coll">IEnumerable to transform to Collection</param>
        /// <returns>A collection created from specified IEnumerable</returns>
        public static ICollection<TEntity> ToCollection<TEntity>(this IEnumerable<TEntity> coll) where TEntity : class => new Collection<TEntity>().AddRange(coll.AsEnumerable());

        /// <summary>
        /// Returns a IEnumerable with randomly selected items from specified Collection
        /// </summary>
        /// <typeparam name="TEntity">Type to use in collection</typeparam>
        /// <param name="coll">Collection to select from</param>
        /// <returns>An IEnumerable with randomly selected items</returns>
        public static IEnumerable<TEntity> Random<TEntity>(this IEnumerable<TEntity> coll) where TEntity : class => Random(coll, coll.Count());

        /// <summary>
        /// Returns a IEnumerable with randomly selected items from specified Collection
        /// </summary>
        /// <typeparam name="TEntity">The type of objects in collection</typeparam>
        /// <param name="coll">Collection to select from</param>
        /// <param name="count">Number of elements to return. If number is higher than items in the collection the length of the collection is used</param>
        /// <returns>An IEnumerable with randomly selected items</returns>
        public static IEnumerable<TEntity> Random<TEntity>(this IEnumerable<TEntity> coll, int count) where TEntity : class
        {
            ICollection<TEntity> result = new Collection<TEntity>();

            using (DataTable data = new DataTable())
            {
                data.Columns.AddRange(new DataColumn[] {
                    new DataColumn("Sort", typeof(Guid)),
                    new DataColumn("Obj", typeof(TEntity))
                });

                foreach (TEntity obj in coll)
                {
                    data.Rows.Add(new object[] { Guid.NewGuid(), obj });
                }

                int i = 1;

                foreach (DataRow r in data.Select("Sort IS NOT null", "Sort"))
                {
                    if (i <= count)
                    {
                        result.Add((TEntity)r["Obj"]);

                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the first elements based on Count
        /// </summary>
        /// <typeparam name="TEntity">Type to handle</typeparam>
        /// <param name="coll">Collection to select from</param>
        /// <param name="count">The number of rows to return</param>
        /// <returns>An IEnumerable with elements selected from the top of Collection</returns>
        public static IEnumerable<TEntity> Top<TEntity>(this IEnumerable<TEntity> coll, int count) where TEntity : class
        {
            ICollection<TEntity> result = new Collection<TEntity>();

            int i = 1;

            foreach (TEntity o in coll)
            {
                if (i <= count)
                {
                    result.Add(o);
                }
            }

            return result;
        }

        /// <summary>
        /// Generates a comma separated list from specified collection
        /// </summary>
        /// <param name="coll">Collection to populate from</param>
        /// <returns>Comma separated list generated from collection</returns>
        public static string ToCommaList<TEntity>(this IEnumerable<TEntity> coll) where TEntity : class
        {
            StringBuilder result = new StringBuilder();

            foreach (TEntity s in coll)
            {
                result.Append(s.ToString() + ", ");
            }

            return result.ToString().TrimEnd(new char[] { ',' });
        }

        /// <summary>
        /// Converts all values to string
        /// </summary>
        /// <param name="coll">Items to convert</param>
        /// <returns>An IEnumerable with string values populated by collection</returns>
        public static IEnumerable<string> ToStrings<TEntity>(this IEnumerable<TEntity> coll) => coll.ToStrings(false);

        /// <summary>
        /// Converts all values to strings or normalized strings
        /// </summary>
        /// <param name="coll">Items to convert</param>
        /// <param name="normalized">If true values will be normalized</param>
        /// <returns>An IEnumerable with string values populated by collection</returns>
        public static IEnumerable<string> ToStrings<TEntity>(this IEnumerable<TEntity> coll, bool normalized)
        {
            ICollection<string> result = new Collection<string>();

            foreach (TEntity i in coll)
            {
                if (normalized)
                {
                    result.Add(i.ToString().ToNormalized());
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }

        /// <summary>
        /// Creates an int array of parsed values
        /// </summary>
        /// <param name="coll">Collection of objects to parse</param>
        /// <exception cref="NotValidException">Throws if a value in collection can't be parsed as int</exception>
        /// <returns>Array of objects in coll parsed to int</returns>
        public static int[] ToIntArray(this IEnumerable<object> coll)
        {
            ICollection<int> result = new Collection<int>();

            foreach (object o in coll)
            {
                try
                {
                    result.Add(int.Parse(o.ToString()));
                }
                catch
                {
                    throw new ArgumentException("Not valid int value");
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Determines if the collection contains elements
        /// </summary>
        /// <param name="coll">Collection to invoke</param>
        /// <returns>True if the collection contains entries</returns>
        public static bool HasRows<TEntity>(this IEnumerable<TEntity> coll) where TEntity : class => coll.Count() > 0;

        /// <summary>
        /// Returns elements from defined query or Default if no elements found
        /// </summary>
        /// <typeparam name="TEntity">Type of object</typeparam>
        /// <param name="coll">Collection to query</param>
        /// <param name="predicate"><Query to run/param>
        /// <returns>Result of the query or Default if no elements was found</returns>
        public static IEnumerable<TEntity> WhereOrDefault<TEntity>(this IEnumerable<TEntity> coll, Func<TEntity, bool> predicate) where TEntity : class
        {
            IEnumerable<TEntity> result = default;
            var tmp = coll.Where(predicate);

            if (tmp.HasRows())
            {
                result = tmp;
            }

            return result;
        }

        /// <summary>
        /// Returns the first element of collection
        /// </summary>
        /// <typeparam name="TEntity">Type of objects in collection</typeparam>
        /// <param name="coll">Collection containing elements</param>
        /// <returns>The first element of the collection. If the collection doesn't contain any rows, Default is returned</returns>
        public static object First(this IEnumerable<object> coll) => coll.ElementAtOrDefault(0);

        /// <summary>
        /// Creates a separated list of elements in Coll separated by the SeperatorSign as a String Array
        /// </summary>
        /// <typeparam name="TEntity">Type of elements in list. Elements will be added as the String representation</typeparam>
        /// <param name="coll">Elements to include in list</param>
        /// <param name="separatorSign">The sign used to separate each element in the string</param>
        /// <returns>A String Array with elements from Coll separated by SeparatorSign</returns>
        public static string[] ToSeparatedStringArray<TEntity>(this IEnumerable<TEntity> coll, string separatorSign = ",", bool trim = false) where TEntity : class
        {
            string[] result = new string[coll.Count()];

            for (int i = 0; i < coll.Count(); i++)
            {
                result[i] = trim ? coll.ElementAt(i).ToString().Trim() : coll.ElementAt(i).ToString();
            }

            return result;
        }

        /// <summary>
        /// Creates a StringBuilder based on IEnumerable collection
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection</typeparam>
        /// <param name="coll">Collection with values to include</param>
        /// <returns>Collection with all elements in the collection as string representations</returns>
        public static StringBuilder ToStringBuilder<TEntity>(this IEnumerable<TEntity> coll) where TEntity : class
        {
            StringBuilder result = new StringBuilder();

            foreach (var c in coll)
            {
                result.Append(c.ToString());
            }

            return result;
        }

        /// <summary>
        /// Uses collection to create a QueryString with all elements as strings
        /// </summary>
        /// <param name="coll">Elements used to populating QueryString</param>
        /// <returns>QueryString generated from collection</returns>
        public static QueryString ToQueryString(this IEnumerable<KeyValuePair<string, string>> coll) => QueryString.Create(coll);

        /// <summary>
        /// Generates a PathString object based on collection
        /// </summary>
        /// <typeparam name="TEntity">Type of object in collection</typeparam>
        /// <param name="coll">Items</param>
        /// <returns>A PathString object with values from collection</returns>
        public static PathString ToWebPath<TEntity>(this IEnumerable<TEntity> coll) where TEntity : class => new PathString(coll.ToStringBuilder().ToString());

        /// <summary>
        /// Generates a PathString object based on colletion and query
        /// </summary>
        /// <typeparam name="TEntity">Type of objects in collection</typeparam>
        /// <param name="coll">Items to generate from</param>
        /// <param name="query">Items to generate QueryString from</param>
        /// <returns>A PathString object including querystring</returns>
        public static PathString ToWebPath<TEntity>(this IEnumerable<TEntity> coll, IEnumerable<KeyValuePair<string, string>> query) where TEntity : class
        {
            PathString result = coll.ToWebPath();
            result.Add(query.ToQueryString());

            return result;
        }

        /// <summary>
        /// Determines if collection contain equals to predicate
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <param name="coll">Collection of elements</param>
        /// <param name="predicate">Query to run against collection</param>
        /// <returns>True if collection contains at least one element equal to predicate</returns>
        public static bool Exists<TEntity>(this IEnumerable<TEntity> coll, Func<TEntity, bool> predicate) where TEntity : class => coll.Count(predicate) > 0;

        /// <summary>
        /// Determines if coll has zero elements
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection</typeparam>
        /// <param name="coll">Collection to process</param>
        /// <returns>True if collection has no elements</returns>
        public static bool Zero<TEntity>(this IEnumerable<TEntity> coll) where TEntity : class => coll.Count() == 0;

        /// <summary>
        /// Indicates if a collection has elements
        /// </summary>
        /// <typeparam name="TEntity">Type of elements in collection</typeparam>
        /// <param name="coll">Collection to process</param>
        /// <returns>True if collection contains elements</returns>
        public static bool HasContent<TEntity>(this IEnumerable<TEntity> coll) where TEntity : class => coll.Count() > 0;

        /// <summary>
        /// Selects distinct elements
        /// </summary>
        /// <typeparam name="TEntity">Type of element</typeparam>
        /// <typeparam name="TKey">Key to compare with</typeparam>
        /// <param name="source">Elements to process</param>
        /// <param name="keySelector">Property to compare with</param>
        /// <returns>Distinct list</returns>
        public static IEnumerable<TEntity> DistinctByKey<TEntity, TKey>(this IEnumerable<TEntity> source, Func<TEntity, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TEntity element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>
        /// Trims all items in collection
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection</typeparam>
        /// <param name="coll">Item to process</param>
        /// <returns>A collection where all items has been trimmed</returns>
        public static IEnumerable<string> TrimStrings(this IEnumerable<string> coll)
        {
            string[] result = coll.ToArray();

            for (int i = 0; i < coll.Count(); i++)
            {
                result[i] = coll.ElementAt(i).Trim();
            }

            return result;
        }

        /// <summary>
        /// Converts an IEnumerable to an array
        /// </summary>
        /// <typeparam name="TEntity">Type of entity in collection</typeparam>
        /// <param name="coll">Collection of entities</param>
        /// <returns>Array with elements from the collection</returns>
        public static TEntity[] ToArray<TEntity>(this IEnumerable<TEntity> coll) where TEntity : class
        {
            TEntity[] result = new TEntity[coll.Count()];

            for (int i = 0; i < coll.Count(); i++)
            {
                result[i] = coll.ElementAt(i);
            }

            return result;
        }

        /// <summary>
        /// Converts an IEnumerable to an IDictionary<string, string> element used for passing data to a Route
        /// </summary>
        /// <param name="coll">Collection to convert</param>
        /// <returns>IDictionary<string, string> with values from collection</returns>
        public static IDictionary<string, string> ToRouteData(this IEnumerable<IObjectPropertyModel> coll)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            foreach(IObjectPropertyModel prop in coll)
            {
                result.Add(prop.Name, prop.Value);
            }

            return result;
        }
    }
}
