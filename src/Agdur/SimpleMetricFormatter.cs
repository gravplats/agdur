using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// Simple formatting.
    /// </summary>
    public class SimpleMetricFormatter : IMetricFormatter
    {
        private readonly object valueOfMetric;

        /// <summary>
        /// Creates a new instance of the <see cref="SimpleMetricFormatter"/> class.
        /// </summary>
        /// <inheritdoc/>
        /// <param name="valueOfMetric">The value of the metric.</param>
        public SimpleMetricFormatter(object valueOfMetric)
        {
            this.valueOfMetric = valueOfMetric;
        }

        /// <inheritdoc/>
        public string GetOutput(string nameOfMetric, string unitOfMeasurement)
        {
            return string.Format("{0}: {1} {2}", nameOfMetric, valueOfMetric, unitOfMeasurement);
        }
    }
}