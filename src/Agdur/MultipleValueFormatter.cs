using System.Collections.Generic;

namespace Agdur
{
    /// <summary>
    /// Format a multiple value result.
    /// </summary>
    public static class MultipleValueFormatter
    {
        /// <summary>
        /// Outputs a formatted string.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        /// <param name="unitOfMeasurement">The unit of measurement of the results of the metric.</param>
        /// <param name="values">The results of the metric.</param>
        /// <returns>A formatted string.</returns>
        public static string Output(string name, string unitOfMeasurement, IList<string> values)
        {
            Ensure.NotNullOrEmpty(name, "name");
            Ensure.NotNullOrEmpty(unitOfMeasurement, "unitOfMeasurement");
            Ensure.NotNull(values, "values");

            string result = string.Join(", ", values);

            int numberOfSamples = values.Count;
            if (numberOfSamples > 1)
            {
                string word = NumberToStringMapper.GetWordOrDefault(numberOfSamples);
                return string.Format("The {0} {1} values are {2} {3}.", name, word, result, unitOfMeasurement);
            }

            return string.Format(SingleValueFormatter.OutputMessage, name, result, unitOfMeasurement);
        }
    }
}