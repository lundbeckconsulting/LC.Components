/*
    @Date			    : 14.07.2020
    @Author			    : Stein Lundbeck
    @Description        : Extensions for enums. Some functionality couldn't be implemented as extension and are implemented as static methods
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LundbeckConsulting.Components.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the source value as lower case
        /// </summary>
        /// <returns>source value as lower case</returns>
        public static string ToLower<TEntity>(this TEntity source) where TEntity : Enum, IConvertible => source.ToUpper().ToLower();

        /// <summary>
        /// Returns the source value as upper case
        /// </summary>
        /// <returns>source value as upper case</returns>
        public static string ToUpper<TEntity>(this TEntity source) where TEntity : Enum, IConvertible => source.ToString().ToUpper();

        /// <summary>
        /// Normalizes the entity value
        /// </summary>
        /// <returns>Enum element as normalized</returns>
        public static string ToNormalized<TEntity>(this TEntity source) where TEntity : Enum, IConvertible => source.ToString().ToNormalized();

        /// <summary>
        /// Gets enum value at equal index
        /// </summary>
        /// <typeparam name="TEnum">Enum to process</typeparam>
        /// <param name="source">Enum type</param>
        /// <param name="index">Index location</param>
        /// <returns>The value at index</returns>
        public static TEnum ElementAt<TEnum>(this TEnum source, int index) where TEnum : Enum, IConvertible => EnumAsEnumerable<TEnum>().ElementAt(index);

        /// <summary>
        /// Returns all values in an enum.
        /// </summary>
        /// <remarks>This is not an extension but a static function</remarks>
        /// <typeparam name="TEnum">Type of entity</typeparam>
        /// <returns>Values in the enum</returns>
        public static IEnumerable<TEnum> EnumAsEnumerable<TEnum>() where TEnum : Enum, IConvertible => Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

        /// <summary>
        /// Gets an enum value with equal name
        /// </summary>
        /// <remarks>This is not an extension but a static function</remarks>
        /// <typeparam name="TEnum">Type of enum to process</typeparam>
        /// <param name="name">Name of the enum value to get</param>
        /// <returns>An instance of an enum value with equal name. Returns default is not found</returns>
        public static TEnum GetItem<TEnum>(string name) where TEnum : Enum, IConvertible
        {
            TEnum result = default;
            bool found = false;

            foreach (TEnum enm in EnumAsEnumerable<TEnum>())
            {
                if (enm.ToString().ToNormalized() == name.ToNormalized())
                {
                    result = enm;
                    found = true;
                }
            }

            return found ? result : default;
        }
    }
}
