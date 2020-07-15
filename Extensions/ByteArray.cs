/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LundbeckConsulting.Components.Extensions
{
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Converts the array to specified object type
        /// </summary>
        /// <typeparam name="TObject">Type to transform to</typeparam>
        /// <returns>An instance of the specified type</returns>
        public static TObject ToObject<TObject>(this byte[] array)
        {
            TObject result = default;
            BinaryFormatter format = new BinaryFormatter();

            using (MemoryStream ms = new MemoryStream(array))
            {
                try
                {
                    result = (TObject)format.Deserialize(ms);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }

        /// <summary>
        /// Compares two byte arrays
        /// </summary>
        /// <returns>True if arrays are equal</returns>
        public static bool Equal(this byte[] array, byte[] compare)
        {
            bool result = false;

            
            if (array.Null() && compare.Null() || array.Length == compare.Length)
            {
                result = true;
            }

            bool tmp = true;

            for(var i = 0;i < array.Length;i++)
            {
                tmp &= array[i] == compare[i];
            }

            result = tmp;

            return result;
        }
    }
}
