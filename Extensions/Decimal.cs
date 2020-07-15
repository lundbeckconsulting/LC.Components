/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Repos;
using System;

namespace LundbeckConsulting.Components.Extensions
{
    public static class DecimalExtensions
    {
        private static IExtensionRepo _repo = new ExtensionRepo();

        /// <summary>
        /// Rounds a number up to nearest whole number.
        /// </summary>
        /// <param name="sum">Number to round up</param>
        /// <returns>Number rounded up to nearest number</returns>
        /// <example>4.56 = 5, 4.48 = 4</example>
        public static decimal RoundUp(this decimal sum) => _repo.RoundUp<decimal>(sum);

        /// <summary>
        /// Returns a boolean indicating if Nr is between Start and End
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <param name="start">The start value</param>
        /// <param name="end">The end value</param>
        /// <returns>Bool that tells if Nr is between Start and End</returns>
        public static bool Between(this decimal sum, decimal start, decimal end) => _repo.IsBetween<decimal>(sum, start, end);

        /// <summary>
        /// Calculated how many percentage Value is of Sum. Rounds up to nearest number with no decimals
        /// </summary>
        /// <param name="sum">Original number</param>
        /// <param name="value">Value to use in the math</param>
        /// <param name="roundValue">Numbers after decimal. Default is 0. When the value is 0 the sum will be rounded up to nearest whole number</param>
        /// <returns>Number of percentages Value is of Nr</returns>
        public static decimal PercentageOf(this decimal sum, decimal value, int? roundValue) => Convert.ToDecimal(_repo.PercentageOf<decimal>(sum, value, roundValue));

        /// <summary>
        /// Subtracts Value from Nr and rounds to RoundValue
        /// </summary>
        /// <param name="sum">Original number</param>
        /// <param name="value">Number to subtract</param>
        /// <param name="roundValue">Values after decimal</param>
        /// <returns>The calculated value of subtracting Value from Nr</returns>
        public static decimal Subtract(this decimal sum, decimal value, int roundValue = 0)
        {
            decimal result = sum - value;

            if (roundValue == 0)
            {
                result = result.RoundUp();
            }
            else
            {
                result = Math.Round(result, roundValue);
            }

            return result;
        }

        /// <summary>
        /// Multiply's Sum with Value and rounds numbers after decimal to roundValue
        /// </summary>
        /// <param name="sum">Original number</param>
        /// <param name="value">Number to multiply with</param>
        /// <param name="roundValue">How many numbers after decimal. If 0 it rounds up to nearest number</param>
        /// <returns>Calculated value of multiplying Nr with Value, rounded to value based on RoundValue</returns>
        public static decimal Multiply(this decimal sum, decimal value, int roundValue = 0)
        {
            decimal result = sum * value;

            if (roundValue == 0)
            {
                result = result.RoundUp();
            }
            else
            {
                result = Math.Round(result, roundValue);
            }

            return result;
        }

        /// <summary>
        /// Transforms a value of type decimal to int. If the Nr contains decimals the Nr is Rounded Up
        /// </summary>
        /// <param name="sum">Number to transform</param>
        /// <returns>The converted value</returns>
        public static int ToInt(this decimal sum) => _repo.ToInt<decimal>(sum);

        /// <summary>
        /// Transforms a value of type decimal to int. If the Nr contains decimals the Nr is Rounded Up
        /// </summary>
        /// <param name="sum">Number to transform</param>
        /// <returns>The converted value</returns>
        public static double ToDouble(this decimal sum) => _repo.ToDouble<decimal>(sum);

        /// <summary>
        /// Transforms a value of type decimal to int. If the Nr contains decimals the Nr is Rounded Up
        /// </summary>
        /// <param name="sum">Number to transform</param>
        /// <returns>The converted value</returns>
        public static float ToFloat(this decimal sum) => _repo.ToFloat<decimal>(sum);

        /// <summary>
        /// Indicates if a number have decimals
        /// </summary>
        /// <returns>Bool value indicating if the number have decimals</returns>
        public static bool ContainDecimals(this decimal sum) => _repo.ContainsDecimals<decimal>(sum);

        /// <summary>
        /// Returns the decimals of specified number
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>Decimals of Nr</returns>
        public static decimal GetDecimals(this decimal sum) => _repo.GetDecimals<decimal>(sum).ToDecimal();

        /// <summary>
        /// Indicates if a number is positive
        /// </summary>
        /// <param name="sum">Number to use</param>
        /// <returns>True if number is equal or greater than 0</returns>
        public static bool IsPositive(this decimal sum) => _repo.IsPositive<decimal>(sum);

        /// <summary>
        /// Calculates number of years based on specified number
        /// </summary>
        /// <param name="sum">Number to use in calculation</param>
        /// <returns>The number of days based on number</returns>
        public static int ToYears(this decimal sum) => _repo.ToYears(int.Parse(sum.ToString()));

        /// <summary>
        /// Determines if the Sum equals 0
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if the Sum equals 0</returns>
        public static bool IsZero(this decimal sum) => _repo.IsZero(sum);

        /// <summary>
        /// Converts Sum to negative
        /// </summary>
        /// <param name="sum">Number to process</param>
        /// <returns>Negative Sum</returns>
        public static decimal ToNegative(this decimal sum) => _repo.ToNegative(sum);

        /// <summary>
        /// Determines if a number is negative
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if Sum is negative</returns>
        public static bool IsNegative(this decimal sum) => _repo.IsPositive<decimal>(sum);

        /// <summary>
        /// Returns a random number between value of Min and I
        /// </summary>
        /// <param name="min">Minimum value</param>
        public static decimal Random(this decimal nr, int min = 0) => _repo.Random(nr.ToDouble(), min).ToInt();
    }
}
