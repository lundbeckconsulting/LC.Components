/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using System;

namespace LundbeckConsulting.Components.Extensions
{
    public static class GuidExtensions
    {
        /// <summary>
        /// Returns Guid without hyphen's
        /// </summary>
        /// <returns>The guid as string without hyphens</returns>
        public static string Trim(this Guid g) => g.ToString().Replace("-", default);

        /// <summary>
        /// Determines if a Guid is equal to empty
        /// </summary>
        /// <returns>True if value equals empty guid</returns>
        public static bool IsEmpty(this Guid g) => g == new Guid();
    }
}
