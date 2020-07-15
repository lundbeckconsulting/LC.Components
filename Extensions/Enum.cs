/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
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
        /// Returns all values in an enum.
        /// </summary>
        /// <remarks>This is not an extension but a static function</remarks>
        /// <typeparam name="TEnum">Type of entity</typeparam>
        /// <returns>Values in the enum</returns>
        public static IEnumerable<TEnum> EnumAsEnumerable<TEnum>() where TEnum : Enum, IConvertible => Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

        /// <summary>
        /// Gets enum value at equal index
        /// </summary>
        /// <typeparam name="TEnum">Enum to process</typeparam>
        /// <param name="source">Enum type</param>
        /// <param name="index">Index location</param>
        /// <returns>The value at index</returns>
        public static TEnum ElementAt<TEnum>(this TEnum source, int index) where TEnum : Enum, IConvertible => EnumAsEnumerable<TEnum>().ElementAt(index);
    }
}
