using Agdur.Introspection;

namespace Agdur.IO
{
    /// <summary>
    /// Formats a single value result.
    /// </summary>
    public static class SingleValueFormatter
    {
        /// <summary>
        /// The output message for a single value result.
        /// </summary>
        public static string OutputMessage = "The {0} value is {1} {2}.";

        /// <summary>
        /// Outputs a formatted string.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        /// <param name="unitOfMeasurement">The unit of measurement of the results of the metric.</param>
        /// <param name="value">The results of the metric.</param>
        /// <returns>A formatted string.</returns>
        public static string Output(string name, string unitOfMeasurement, string value)
        {
            Ensure.NotNullOrEmpty(name, "name");
            Ensure.NotNullOrEmpty(unitOfMeasurement, "unitOfMeasurement");
            Ensure.NotNullOrEmpty(value, "value");

            return string.Format(OutputMessage, name, value, unitOfMeasurement);
        }
    }
}