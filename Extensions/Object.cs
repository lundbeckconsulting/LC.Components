/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Extensions.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
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
        public static bool Equal(this object obj, object compare) => !obj.Null() && !compare.Null() && obj.ToNormalized() == compare.ToNormalized();

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

        /// <summary>
        /// Element as normalized string
        /// </summary>
        /// <returns>Normalized string value of object</returns>
        public static string ToNormalized(this object obj) => obj.ToString().ToNormalized();

        /// <summary>
        /// Applies supplied element if original value is null
        /// </summary>
        /// <typeparam name="TType">Type of element</typeparam>
        /// <param name="obj">Element to evaluate</param>
        /// <param name="element">Object to return if Obj is null</param>
        /// <returns>Value of element if original value is null</returns>
        public static TType ApplyIfNull<TType>(this object obj, TType element) where TType : class
        {
            if (obj.Null())
            {
                return element;
            }
            else
            {
                return (TType)obj;
            }
        }

        /// <summary>
        /// Returns a list of properties of the Obj element
        /// </summary>
        /// <param name="obj">Element to evaluate</param>
        /// <returns>List of object properties</returns>
        public static IEnumerable<IObjectPropertyModel> GetProperties(this object obj)
        {
            ICollection<IObjectPropertyModel> result = new Collection<IObjectPropertyModel>();

            foreach (var prop in obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                result.Add(new ObjectPropertyModel()
                {
                    Info = prop,
                    Name = prop.Name,
                    Value = prop.GetValue(obj, null).ToString()
                });
            }

            return result;
        }

        /// <summary>
        /// Converts an objects Properties and values to an IDictinary<string, string> collection
        /// </summary>
        /// <param name="obj">Element to evaluate</param>
        /// <returns>Collection of property names and values</returns>
        public static IDictionary<string, string> ToRouteData(this object obj)
        {
            IDictionary<string, string> result = new Dictionary<string, string>();

            foreach (IObjectPropertyModel prop in obj.GetProperties())
            {
                result.Add(prop.Name, prop.Value);
            }

            return result;
        }
    }
}
