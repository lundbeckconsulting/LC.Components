/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using System;

namespace LundbeckConsulting.Components.Extensions
{
    public static class TimespanExtensions
    {
        /// <summary>
        /// Calculates the number of years base on a TimeSpan object
        /// </summary>
        /// <param name="ts">Value to evaluate</param>
        /// <returns>Number of years based on TimeSpan</returns>
        public static int TotalYears(this TimeSpan ts) => Math.Round(ts.TotalDays / 365.25, 0).ToInt();
    }
}
