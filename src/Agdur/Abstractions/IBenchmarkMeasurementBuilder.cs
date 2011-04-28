namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the type of measurement that should be used for presenting the metric.
    /// </summary>
    public interface IBenchmarkMeasurementBuilder : IFluentSyntax
    {
        /// <summary>
        /// States that the metric should be in milliseconds.
        /// </summary>
        IBenchmarkOutputBuilder InMilliseconds();

        /// <summary>
        /// States that the metric should be in milliseconds.
        /// </summary>
        IBenchmarkOutputBuilder InTicks();
    }
}