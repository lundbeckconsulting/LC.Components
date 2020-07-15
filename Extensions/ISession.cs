/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using Microsoft.AspNetCore.Http;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LundbeckConsulting.Components.Extensions
{
    public static class ISessionExtensions
    {
        /// <summary>
        /// Deseralizeses session object to defined TEntity
        /// </summary>
        /// <typeparam name="TEntity">Type to deserialize to</typeparam>
        /// <param name="key">Key of session to process</param>
        /// <returns>Object in session as TEntity</returns>
        public static TEntity ToObject<TEntity>(this ISession session, string key) where TEntity : class
        {
            TEntity result = default;
            byte[] val = session.Get(key);

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter binary = new BinaryFormatter();
                ms.Write(val, 0, val.Length);
                ms.Seek(0, SeekOrigin.Begin);

                result = (TEntity)binary.Deserialize(ms);
            }

            return result;
        }
    }
}
