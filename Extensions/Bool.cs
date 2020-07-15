/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

namespace LundbeckConsulting.Components.Extensions
{
    public static class BoolExtensions
    {
        /// <summary>
        /// Casts bool to int
        /// </summary>
        /// <param name="value">Value to cast</param>
        /// <returns>Returns 0 of Value is false or 1 if true</returns>
        public static int ToInt(this bool value) => value ? 1 : 0;

        /// <summary>
        /// Returns the defined Str if Value is true
        /// </summary>
        /// <param name="value">Bool to check</param>
        /// <param name="str">String to return</param>
        /// <returns>The specified string if Value is true</returns>
        public static string AppendIfTrue(this bool value, string str) => value ? str : string.Empty;

        /// <summary>
        /// Returns the defined Str if Value is false
        /// </summary>
        /// <param name="value">Bool to check</param>
        /// <param name="str">String to return</param>
        /// <returns>The specified string if Value is false</returns>
        public static string AppendIfFalse(this bool value, string str) => value ? string.Empty : str;

        /// <summary>
        /// Returns a random bool value
        /// </summary>
        /// <returns>Random bool value</returns>
        public static bool Random(this bool value) => 1.Random().ToBool();
    }
}
