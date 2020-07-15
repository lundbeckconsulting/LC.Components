/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Repos;

namespace LundbeckConsulting.Components.Extensions
{
    public static class IntExtensions
    {
        private static ExtensionRepo _repo = new ExtensionRepo();

        /// <summary>
        /// Returns a random number between value of Min and I
        /// </summary>
        /// <param name="min">Minimum value</param>
        public static int Random(this int nr, int min = 0) => _repo.Random(nr, min).ToInt();

        /// <summary>
        /// Adds all the values in the I array
        /// </summary>
        /// <param name="nr">Values to use in addition</param>
        /// <returns>Result of addition</returns>
        public static int Addition(this int[] nr)
        {
            int result = 0;

            foreach (int n in nr)
            {
                result += n;
            }

            return result;
        }

        /// <summary>
        /// Calculates how many percentage Value is of I
        /// </summary>
        /// <param name="nr">Main number</param>
        /// <param name="value">Number to evaluate</param>
        /// <returns>How many percentage Value is of I</returns>
        public static double Percentage(this int nr, int value) => _repo.PercentageOf<int>(nr, value);

        /// <summary>
        /// Subtracts Value from I
        /// </summary>
        /// <param name="nr">Original value</param>
        /// <param name="value">Value to subtract</param>
        /// <returns>Calculated value of subtracting Value from I</returns>
        public static int Subtract(this int nr, int value) => nr - value;

        /// <summary>
        /// Returns a bool value indicating if I is greater than zero
        /// </summary>
        /// <param name="nr">Value to cast</param>
        /// <returns>Returns true if I is bigger than zero</returns>
        public static bool ToBool(this int nr) => nr > 0;

        /// <summary>
        /// Calculates the number of years from number of days
        /// </summary>
        /// <param name="days">Number of days to calculate</param>
        /// <returns>Number of years calculated from Days</returns>
        public static int ToYears(this int days) => _repo.ToYears(days);

        /// <summary>
        /// Returns a bool indicating if the number is positive
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if number is equal or greater than 0</returns>
        public static bool IsPositive(this int sum) => sum > -1;

        /// <summary>
        /// Determines if the Sum equals 0
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if the Sum equals 0</returns>
        public static bool Zero(this int sum) => sum == 0;

        /// <summary>
        /// Converts Sum to negative
        /// </summary>
        /// <param name="sum">Number to process</param>
        /// <returns>Negative Sum</returns>
        public static int ToNegative(this int sum) => sum * (sum.IsNegative() ? 0 : -1);

        /// <summary>
        /// Determines if a number is negative
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if Sum is negative</returns>
        public static bool IsNegative(this int sum) => sum < 0;

        /// <summary>
        /// Transforms a value of type decimal to int. If the Nr contains decimals the Nr is Rounded Up
        /// </summary>
        /// <param name="sum">Number to transform</param>
        /// <returns>The converted value</returns>
        public static double ToDouble(this int sum) => _repo.ToDouble<int>(sum);

        /// <summary>
        /// Transforms a value of type decimal to int. If the Nr contains decimals the Nr is Rounded Up
        /// </summary>
        /// <param name="sum">Number to transform</param>
        /// <returns>The converted value</returns>
        public static decimal ToDecimal(this int sum) => _repo.ToDecimal<decimal>(sum);

        /// <summary>
        /// Transforms a value of type decimal to int. If the Nr contains decimals the Nr is Rounded Up
        /// </summary>
        /// <param name="sum">Number to transform</param>
        /// <returns>The converted value</returns>
        public static float ToFloat(this int sum) => _repo.ToFloat<int>(sum);
    }
}
