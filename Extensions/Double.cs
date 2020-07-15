/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Repos;
using System;

namespace LundbeckConsulting.Components.Extensions
{
    public static class DoubleExtensions
    {
        private static IExtensionRepo _repo = new ExtensionRepo();

        /// <summary>
        /// Rounds a number up to nearest whole number.
        /// </summary>
        /// <param name="sum">Number to round up</param>
        /// <returns>Number rounded up to nearest number</returns>
        /// <example>4.56 = 5, 4.48 = 4</example>
        public static double RoundUp(this double sum) => _repo.RoundUp<double>(sum);

        /// <summary>
        /// Calculates the number of years from number of days
        /// </summary>
        /// <param name="days">Number of days used to calculate</param>
        /// <returns>Number of years based on specified Days</returns>
        public static int ToYears(this double days) => _repo.ToYears(Convert.ToInt32(days));

        /// <summary>
        /// Transforms a value of type decimal to int. If the Nr contains decimals the Nr is Rounded Up
        /// </summary>
        /// <param name="sum">Number to transform</param>
        /// <returns>The converted value</returns>
        public static int ToInt(this double sum) => _repo.ToInt<double>(sum);

        /// <summary>
        /// Transforms a value of type decimal to int. If the Nr contains decimals the Nr is Rounded Up
        /// </summary>
        /// <param name="sum">Number to transform</param>
        /// <returns>The converted value</returns>
        public static decimal ToDecimal(this double sum) => _repo.ToDecimal<double>(sum);

        /// <summary>
        /// Transforms a value of type decimal to int. If the Nr contains decimals the Nr is Rounded Up
        /// </summary>
        /// <param name="sum">Number to transform</param>
        /// <returns>The converted value</returns>
        public static float ToFloat(this double sum) => _repo.ToFloat<double>(sum);

        /// <summary>
        /// Indicates if a number have decimals
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>Bool value indicating if sum have decimals</returns>
        public static bool ContainDecimals(this double sum) => _repo.ContainsDecimals<double>(sum);

        /// <summary>
        /// Returns only the decimals of specified number
        /// </summary>
        /// <param name="sum">Number to extract decimals from</param>
        /// <returns>Decimals of sum</returns>
        public static double GetDecimals(this double sum) => Convert.ToDouble(_repo.GetDecimals<double>(sum));

        /// <summary>
        /// Indicates if a number is positive
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if number is equal or greater than 0</returns>
        public static bool IsPositive(this double sum) => _repo.IsPositive<double>(sum);

        /// <summary>
        /// Calculates how many percentages a supplied number is of Sum
        /// </summary>
        /// <param name="sum">The base number</param>
        /// <param name="value">The number to evaluate</param>
        /// <returns>How many percentages Value is of sum</returns>
        public static double PercentageOf(this double sum, double value, int? roundValue = default) => _repo.PercentageOf<double>(sum, value, roundValue);

        /// <summary>
        /// Determines if the Sum equals 0
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if the Sum equals 0</returns>
        public static bool IsZero(this double sum) => _repo.IsZero(sum);

        /// <summary>
        /// Returns a random number between value of Min and I
        /// </summary>
        /// <param name="min">Minimum value</param>
        public static double Random(this double nr, int min = 0) => _repo.Random(nr, min).ToInt();
    }
}
