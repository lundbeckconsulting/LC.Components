/*
    @Date			 : 14.07.2020
    @Author			 : Stein Lundbeck
*/

using LundbeckConsulting.Components.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LundbeckConsulting.Components.Repos
{
    public interface IExtensionRepo : IRepoBase
    {
        /// <summary>
        /// Indicates if the Sum is greater than zero
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if Sum is greater than zero</returns>
        bool IsPositive<TEntity>(TEntity sum);

        /// <summary>
        /// Indicates if Sum contains decimals
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if Sum contains decimals</returns>
        bool ContainsDecimals<TEntity>(TEntity sum);

        /// <summary>
        /// Selects the decimals of Sum
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>The decimals of Sum</returns>
        double GetDecimals<TEntity>(TEntity sum);

        /// <summary>
        /// Converts Sum to Int
        /// </summary>
        /// <param name="sum">Number to process</param>
        /// <returns>An Int value converted from Sum</returns>
        int ToInt<TEntity>(TEntity sum);

        /// <summary>
        /// Converts Sum to Double
        /// </summary>
        /// <param name="sum">Number to process</param>
        /// <returns>An Double value converted from Sum</returns>
        double ToDouble<TEntity>(TEntity sum);

        /// <summary>
        /// Converts Sum to Float
        /// </summary>
        /// <param name="sum">Number to process</param>
        /// <returns>An Float value converted from Sum</returns>
        float ToFloat<TEntity>(TEntity sum);

        /// <summary>
        /// Converts Sum to Decimal
        /// </summary>
        /// <param name="sum">Number to process</param>
        /// <returns>An Decimal value converted from Sum</returns>
        decimal ToDecimal<TEntity>(TEntity sum);

        /// <summary>
        /// Calculates how many percentages Sub is of Main
        /// </summary>
        /// <param name="main">The base number to calculate</param>
        /// <param name="sub">The number used to calculate percentage of Main</param>
        /// <param name="roundValue"></param>
        /// <returns>How many percentages Sub is of Main</returns>
        double PercentageOf<TEntity>(TEntity main, TEntity sub, int? roundValue = default);

        /// <summary>
        /// Selects a sub collection containing elements from Collection with Index value between From and To
        /// </summary>
        /// <typeparam name="T">Collection object types</typeparam>
        /// <param name="coll">Elements to process</param>
        /// <param name="from">The index number to start from</param>
        /// <param name="to">The index number to end with. If null the collection count is used</param>
        /// <returns>A sub collection containing elements with index value between From and To</returns>
        IEnumerable<TEntity> CollectionBetween<TEntity>(IEnumerable<TEntity> coll, int from, int? to) where TEntity : class;

        /// <summary>
        /// Calculates number of years from Sum value
        /// </summary>
        /// <param name="sum">Number to calculate</param>
        /// <returns>The numbers of years calculated from Sum</returns>
        int ToYears(int sum);

        /// <summary>
        /// Rounds the Sum to nearest Int
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>An Int value containing the Sum rounded up</returns>
        int RoundUp<TEntity>(TEntity sum);

        /// <summary>
        /// Determines if Sum equals 0
        /// </summary>
        /// <param name="sum">Number to evaluate</param>
        /// <returns>True if Sum equals 0</returns>
        bool IsZero(object sum);

        /// <summary>
        /// Returns a random number between value of Min and I
        /// </summary>
        /// <param name="min">Minimum value</param>
        double Random(double sum, int min = 0);

        /// <summary>
        /// Indicates if Sum is bigger than Start and smaller than End
        /// </summary>
        /// <typeparam name="TNumeric"></typeparam>
        /// <param name="sum"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>True if Sum is bigger than Start and smaller than End</returns>
        bool IsBetween<TEntity>(TEntity sum, TEntity start, TEntity end);

        /// <summary>
        /// Removed diacritics access
        /// </summary>
        /// <param name="text">Value to process</param>
        /// <returns>Definex text with diacritics access removed</returns>
        string RemoveDiacritics(string text);

        /// <summary>
        /// Converts a sum to a negative number
        /// </summary>
        /// <param name="sum">Number to process</param>
        double ToNegative(double sum);

        /// <summary>
        /// Converts a sum to a negative number
        /// </summary>
        /// <param name="sum">Number to process</param>
        decimal ToNegative(decimal sum);

        /// <summary>
        /// Converts a sum to a negative number
        /// </summary>
        /// <param name="sum">Number to process</param>
        int ToNegative(int sum);

        /// <summary>
        /// Converts a sum to a negative number
        /// </summary>
        /// <param name="sum">Number to process</param>
        float ToNegative(float sum);

        /// <summary>
        /// Indicates if a type is an enum
        /// </summary>
        /// <typeparam name="TEntity">Type to process</typeparam>
        /// <returns>True if TEntity is an enum</returns>
        bool IsEnum<TEntity>() where TEntity : Enum, IConvertible;
    }

    /// <summary>
    /// Tools for different extensions
    /// </summary>
    public sealed class ExtensionRepo : RepoBase, IExtensionRepo
    {
        public bool IsPositive<TEntity>(TEntity sum)
        {
            var tmp = double.Parse(sum.ToString());

            return (tmp > -1);
        }

        public bool ContainsDecimals<TEntity>(TEntity sum)
        {
            var tmp = double.Parse(sum.ToString());

            return (tmp % 1) > 0;
        }

        public double GetDecimals<TEntity>(TEntity sum) => Convert.ToDouble((Convert.ToDouble(sum) - Math.Truncate(Convert.ToDouble(sum))));

        public int ToInt<TEntity>(TEntity sum) => Convert.ToInt32(sum);

        public decimal ToDecimal<TEntity>(TEntity sum) => Convert.ToDecimal(sum);

        public double ToDouble<TEntity>(TEntity sum) => Convert.ToDouble(sum);

        public float ToFloat<TEntity>(TEntity sum) => float.Parse(sum.ToString());

        public double PercentageOf<TEntity>(TEntity main, TEntity sub, int? roundValue = default)
        {
            double result = (Convert.ToDouble(Convert.ToDouble(main) / 100) * Convert.ToDouble(sub));

            if (roundValue.HasValue)
            {
                if (roundValue.Value.Equals(0))
                {
                    result = result.RoundUp();
                }
                else
                {
                    result = (double)Math.Round((decimal)result, roundValue.Value);
                }
            }

            return result;
        }

        public IEnumerable<TEntity> CollectionBetween<TEntity>(IEnumerable<TEntity> coll, int from, int? to) where TEntity : class
        {
            if (from > 0)
            {
                if (to.HasValue && to.Value <= from)
                {
                    throw new ArgumentOutOfRangeException($"To \"{to}\" must be greater than From \"{from}\"");
                }
                else if (!to.HasValue || to.Value > coll.Count())
                {
                    to = coll.Count();
                }

                if (from >= to.GetValueOrDefault())
                {
                    throw new ArgumentOutOfRangeException($"From {from} must be smaller than To {to}");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException($"From value {from} must be greater than 0");
            }

            ICollection<TEntity> result = new Collection<TEntity>();
            double cnt = to.Value - from;

            for (int i = 0; i <= cnt; i++)
            {
                if (i >= from - 1 && i <= to - 1)
                {
                    result.Add(coll.ElementAt(i));
                }
            }

            return result;
        }

        public int ToYears(int sum) => new TimeSpan(sum, 1, 1, 1).TotalYears();

        public int RoundUp<TEntity>(TEntity sum)
        {
            int result = Convert.ToInt32(sum);
            decimal decimals = GetDecimals(sum).ToDecimal();

            if (decimals > 0)
            {
                result++;
            }

            return result;
        }

        public bool IsZero(object sum) => sum.ToString().Equals("0");

        public double Random(double sum, int min = 0)
        {
            double result = default;
            int nr = sum.ToInt();

            if (min < nr)
            {
                nr++;

                result = new Random().Next(min, nr);
            }
            else
            {
                throw new ArgumentException($"The minimum value {min}, can't be greater than {nr}");
            }

            return result;
        }

        public bool IsBetween<TNumeric>(TNumeric sum, TNumeric start, TNumeric end)
        {
            double s = double.Parse(sum.ToString());
            double st = double.Parse(start.ToString());
            double e = double.Parse(end.ToString());

            return s >= st && s <= e;
        }

        public string RemoveDiacritics(string text)
        {
            var s = new string(text.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            return s.Normalize(NormalizationForm.FormC);
        }

        public double ToNegative(double sum) => (!sum.IsPositive() ? 0 : -1);

        public decimal ToNegative(decimal sum) => decimal.Parse(ToNegative(double.Parse(sum.ToString())).ToString());

        public float ToNegative(float sum) => float.Parse(ToNegative(double.Parse(sum.ToString())).ToString());

        public int ToNegative(int sum) => int.Parse(ToNegative(double.Parse(sum.ToString())).ToString());

        public bool IsEnum<TEntity>() where TEntity : Enum, IConvertible
        {
            return typeof(TEntity).IsEnum;
        }
    }
}
