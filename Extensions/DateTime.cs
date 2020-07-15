/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using System;

namespace LundbeckConsulting.Components.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// The Short pattern (dd.MM)
        /// </summary>
        public const string ShortPattern = "dd.MM";

        /// <summary>
        /// The Medium pattern (dd.MM.yy)
        /// </summary>
        public const string MediumPattern = ShortPattern + ".yy";

        /// <summary>
        /// The Long pattern (dd.MM.yyyy")
        /// </summary>
        public const string LongPattern = MediumPattern + "yy";

        /// <summary>
        /// Returns supplied date in short format
        /// </summary>
        /// <param name="date">Date to cast</param>
        /// <returns>The date with format dd.MM</returns>
        public static string ToShortFormated(this DateTime date) => date.ToString(ShortPattern);

        /// <summary>
        /// Returns supplied date in Medium format
        /// </summary>
        /// <param name="date">Date to cast</param>
        /// <returns>The date with format dd.MM.yy</returns>
        public static string ToMediumFormated(this DateTime date) => date.ToString(MediumPattern);

        /// <summary>
        /// Returns supplied date in Long format
        /// </summary>
        /// <param name="date">Date to cast</param>
        /// <returns>The date with format dd.MM.yyyy</returns>
        public static string ToLongFormated(this DateTime date) => date.ToString(LongPattern);

        /// <summary>
        /// Substracts days
        /// </summary>
        /// <param name="date">Date to use</param>
        /// <param name="days">How many days to subtract</param>
        /// <returns>DateTime with specified years subtracted</returns>
        public static DateTime SubtractDays(this DateTime date, int days) => date.AddDays(days * -1);

        /// <summary>
        /// Substracts months
        /// </summary>
        /// <param name="date">Date to use</param>
        /// <param name="months">How many months to subtract</param>
        /// <returns>DateTime with specified years subtracted</returns>
        public static DateTime SubtractMonths(this DateTime date, int months) => date.AddMonths(months * -1);

        /// <summary>
        /// Substracts years
        /// </summary>
        /// <param name="date">Date to use</param>
        /// <param name="years">How many years to subtract</param>
        /// <returns>DateTime with specified years subtracted</returns>
        public static DateTime SubtractYears(this DateTime date, int years) => date.AddYears(years * -1);

        /// <summary>
        /// Calculated the difference between two dates
        /// </summary>
        /// <param name="date">Start date</param>
        /// <param name="dateDiff">End date</param>
        /// <returns>Difference between the specified dates</returns>
        public static DateTime Diff(this DateTime date, DateTime dateDiff)
        {
            TimeSpan ts = date.Subtract(dateDiff);

            return new DateTime(ts.Ticks);
        }

        /// <summary>
        /// How many days there are in the specified month of date
        /// </summary>
        /// <param name="date">Date with month</param>
        /// <returns>Number of days in specified month</returns>
        public static int DaysCount(this DateTime date) => DateTime.DaysInMonth(date.Year, date.Month);
    }
}
