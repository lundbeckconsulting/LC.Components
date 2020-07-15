/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Repos;

namespace LundbeckConsulting.Components.Extensions
{
    public static class FloatExtensions
    {
        private static IExtensionRepo _repo = new ExtensionRepo();

        /// <summary>
        /// Calculate percentages
        /// </summary>
        /// <param name="sum">Number to calculate</param>
        /// <param name="value">Percentage value</param>
        /// <returns>The calculated percentage</returns>
        public static float PercentageOf(this float sum, int value, int? roundValue = default) => float.Parse(_repo.PercentageOf<float>(sum, value, roundValue).ToString());

        /// <summary>
        /// Returns only the decimals of specified number
        /// </summary>
        /// <param name="sum">Number to extract decimals from</param>
        /// <returns>Decimals of a float number</returns>
        public static double GetDecimals(this float sum) => _repo.GetDecimals<float>(sum);

        /// <summary>
        /// Indicates if a number is positive
        /// </summary>
        /// <param name="sum">Number to use</param>
        /// <returns>True if number is positive</returns>
        public static bool IsPositive(this float sum) => _repo.IsPositive<float>(sum);

        /// <summary>
        /// Calculates the number of years from number of days
        /// </summary>
        /// <param name="days">Number of days used to calculate</param>
        /// <returns>Number of years based on specified Days</returns>
        public static int ToYears(this float days) => _repo.ToYears(days.ToInt());

        /// <summary>
        /// Rounds a number up to nearest whole number.
        /// </summary>
        /// <param name="sum">Number to round up</param>
        /// <returns>Number rounded up to nearest number</returns>
        /// <example>4.56 = 5, 4.48 = 4</example>
        public static float RoundUp(this float sum) => _repo.RoundUp<float>(sum);

        /// <summary>
        /// Converts value to Int
        /// </summary>
        /// <returns>An int value based on specified value</returns>
        public static int ToInt(this float sum) => _repo.ToInt<float>(sum);

        /// <summary>
        /// Converts value to Double
        /// </summary>
        /// <returns>An int value based on specified value</returns>
        public static double ToDouble(this float sum) => _repo.ToDouble<float>(sum);

        /// <summary>
        /// Converts value to Decimal
        /// </summary>
        /// <returns>An int value based on specified value</returns>
        public static decimal ToDecimal(this float sum) => _repo.ToDecimal<float>(sum);

        /// <summary>
        /// Determines if the Sum equals 0
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if the Sum equals 0</returns>
        public static bool Zero(this float sum) => sum == 0;
    }
}
