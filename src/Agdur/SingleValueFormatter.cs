using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// Formats a single value result.
    /// </summary>
    public class SingleValueFormatter : IMetricFormatter
    {
        /// <summary>
        /// The output message for a single value result.
        /// </summary>
        public static string OutputMessage = "The {0} value is {1} {2}.";

        private readonly object valueOfMetric;

        /// <summary>
        /// Creates a new instance of the <see cref="SingleValueFormatter"/> class.
        /// </summary>
        /// <param name="valueOfMetric">The value of the metric.</param>
        public SingleValueFormatter(object valueOfMetric)
        {
            this.valueOfMetric = valueOfMetric;
        }

        /// <inheritdoc/>
        public string GetOutput(string nameOfMetric, string unitOfMeasurement)
        {
            return string.Format(OutputMessage, nameOfMetric, valueOfMetric, unitOfMeasurement);
        }
    }
}