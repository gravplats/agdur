using System.Collections.Generic;

namespace Agdur.IO
{
    /// <summary>
    /// Provides functionality for converting a number to a string (or word).
    /// </summary>
    public static class NumberToStringMapper
    {
        private static readonly IDictionary<int, string> NumberToWordMap;

        static NumberToStringMapper()
        {
            NumberToWordMap = new Dictionary<int, string>
            {
                { 1, "one" }, { 2, "two"}, { 3, "three"}, { 4, "four"}, { 5, "five"}, { 6, "six"}, { 7, "seven"}, { 8, "eight"}, { 9, "nine"}
            };
        }

        /// <summary>
        /// Spells out the single-digit whole numbers and uses the string representation of the numeral for numbers greater than nine.
        /// </summary>
        /// <param name="number">The number that should be returned as a word or a string.</param>
        /// <returns>A word or a string of the specified number.</returns>
        public static string GetWordOrDefault(int number)
        {
            string word;
            if (NumberToWordMap.TryGetValue(number, out word))
            {
                return word;
            }

            return number.ToString();
        }
    }
}