namespace Agdur.Abstractions
{
    /// <summary>
    /// Provides a functionality for formatting the output.
    /// </summary>
    public interface IMetricFormatter
    {
        /// <summary>
        /// Returns formatted output.
        /// </summary>
        /// <param name="nameOfMetric">The name of the metric.</param>
        /// <param name="unitOfMeasurement">The unit of measurement.</param>
        /// <returns>Formatted output.</returns>
        string GetOutput(string nameOfMetric, string unitOfMeasurement);
    }
}