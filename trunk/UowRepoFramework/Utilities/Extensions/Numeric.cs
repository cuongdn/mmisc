using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Utilities.Extensions
{
    /// <summary>
    ///     Summary for the Numbers class
    /// </summary>
    public static class Numeric
    {
        /// <summary>
        ///     Determines whether a number is a natural number (positive, non-decimal)
        /// </summary>
        /// <param name="sItem">The s item.</param>
        /// <returns>
        ///     <c>true</c> if [is natural number] [the specified s item]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNaturalNumber(this string sItem)
        {
            var notNaturalPattern = new Regex("[^0-9]");
            var naturalPattern = new Regex("0*[1-9][0-9]*");

            return !notNaturalPattern.IsMatch(sItem) && naturalPattern.IsMatch(sItem);
        }

        /// <summary>
        ///     Determines whether [is whole number] [the specified s item].
        /// </summary>
        /// <param name="sItem">The s item.</param>
        /// <returns>
        ///     <c>true</c> if [is whole number] [the specified s item]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWholeNumber(this string sItem)
        {
            var notWholePattern = new Regex("[^0-9]");
            return !notWholePattern.IsMatch(sItem);
        }

        /// <summary>
        ///     Determines whether the specified s item is integer.
        /// </summary>
        /// <param name="sItem">The s item.</param>
        /// <returns>
        ///     <c>true</c> if the specified s item is integer; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInteger(this string sItem)
        {
            var notIntPattern = new Regex("[^0-9-]");
            var intPattern = new Regex("^-[0-9]+$|^[0-9]+$");

            return !notIntPattern.IsMatch(sItem) && intPattern.IsMatch(sItem);
        }

        /// <summary>
        ///     Determines whether the specified s item is number.
        /// </summary>
        /// <param name="sItem">The s item.</param>
        /// <returns>
        ///     <c>true</c> if the specified s item is number; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNumber(this string sItem)
        {
            double result;
            return (double.TryParse(sItem, NumberStyles.Float, NumberFormatInfo.CurrentInfo, out result));
        }

        /// <summary>
        ///     Determines whether the specified value is an even number.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <c>true</c> if the specified value is even; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEven(this int value)
        {
            return ((value & 1) == 0);
        }

        /// <summary>
        ///     Determines whether the specified value is an odd number.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///     <c>true</c> if the specified value is odd; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOdd(this int value)
        {
            return ((value & 1) == 1);
        }

        /// <summary>
        ///     Generates a random number with an upper bound
        /// </summary>
        /// <param name="high">The high.</param>
        /// <returns></returns>
        public static int Random(int high)
        {
            var random = new Byte[4];
            new RNGCryptoServiceProvider().GetBytes(random);
            var randomNumber = BitConverter.ToInt32(random, 0);

            return Math.Abs(randomNumber%high);
        }

        /// <summary>
        ///     Generates a random number between the specified bounds
        /// </summary>
        /// <param name="low">The low.</param>
        /// <param name="high">The high.</param>
        /// <returns></returns>
        public static int Random(int low, int high)
        {
            return new Random().Next(low, high);
        }

        /// <summary>
        ///     Generates a random double
        /// </summary>
        /// <returns></returns>
        public static double Random()
        {
            return new Random().NextDouble();
        }
    }
}