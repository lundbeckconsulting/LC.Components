/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LundbeckConsulting.Components.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Returns the object as a byte array
        /// </summary>
        /// <param name="obj">Object to transform</param>
        /// <returns>Byte array of defined object</returns>
        public static byte[] ToByteArray(this object obj)
        {
            byte[] result = default;
            BinaryFormatter format = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream())
            {
                format.Serialize(ms, obj);

                result = ms.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Determines if an object is Default or Null
        /// </summary>
        /// <returns>Returns True if obj equals Null</returns>
        public static bool Null(this object obj) => obj is null || obj == default;

        /// <summary>
        /// Wraps a single a object in an array.
        /// </summary>
        /// <typeparam name="TEntity">Type of object to wrap</typeparam>
        /// <param name="obj">Object to return as an array</param>
        /// <returns>An array with a single value</returns>
        public static TEntity[] ToSingleArray<TEntity>(this object obj) where TEntity : class
        {
            TEntity[] result = new TEntity[1];

            try
            {
                result[0] = (TEntity)obj;
            }
            catch
            {
                throw new ArgumentException($"Obj must be of same type as TEntity \"{typeof(TEntity)}\"");
            }

            return result;
        }

        /// <summary>
        /// Serializes an object to a JSON string
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>Object as JSON</returns>
        public static string ToJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Indicates if any ekenent is equal to object
        /// </summary>
        /// <typeparam name="TEntity">Type of elements</typeparam>
        /// <param name="obj">Element to compare against</param>
        /// <param name="compare">Elements to compare</param>
        /// <returns>True if obj equals compare</returns>
        public static bool Equal(this object obj, object compare) => !obj.Null() && !compare.Null() && obj.ToString().ToNormalized() == compare.ToString().ToNormalized();

        /// <summary>
        /// Determines if objects are equal to current object
        /// </summary>
        /// <param name="obj">Object to compare against</param>
        /// <param name="vals">Objects to compare</param>
        /// <returns>True if all values are equal to the object</returns>
        public static bool Equals(this object obj, params object[] vals)
        {
            bool result = true;

            foreach (object o in vals)
            {
                if (!obj.Equal(o))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Element as upper case string
        /// </summary>
        /// <returns>String value of object in lower case</returns>
        public static string ToLower(this object obj) => obj.ToString().ToLower();

        /// <summary>
        /// Element as lower case string
        /// </summary>
        /// <returns>String value of object in upper casev</returns>
        public static string ToUpper(this object obj) => obj.ToString().ToUpper();
    }
}
