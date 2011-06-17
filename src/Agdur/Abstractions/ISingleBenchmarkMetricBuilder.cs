namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the type of metric.
    /// </summary>
    public interface ISingleBenchmarkMetricBuilder : IFluentSyntax
    {
        /// <summary>
        /// Specifies that the single value of the sample should be displayed.
        /// </summary>
        ISingleBenchmarkMeasurementBuilder Value();
    }
}