/*
    @Date			 : 14.077.2020
    @Author			 : Stein Lundbeck
*/

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LundbeckConsulting.Components.Extensions
{
    public static class IQueryCollectionExtensions
    {
        /// <summary>
        /// Creates an Enumerable from the collection
        /// </summary>
        /// <param name="coll">Elements used to populate Enumerable</param>
        /// <returns>An Enumerable created with elements in collection</returns>
        public static IEnumerable<KeyValuePair<string, string>> AsEnumerable(this IQueryCollection coll)
        {
            ICollection<KeyValuePair<string, string>> tmp = new Collection<KeyValuePair<string, string>>();

            foreach(var e in coll)
            {
                tmp.Add(new KeyValuePair<string, string>(e.Key, e.Value));
            }

            return tmp;
        }
    }
}