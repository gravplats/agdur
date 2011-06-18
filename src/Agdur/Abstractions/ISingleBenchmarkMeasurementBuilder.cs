using System;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the type of measurement that should be used for presenting the metric.
    /// </summary>
    public interface ISingleBenchmarkMeasurementBuilder : IFluentSyntax
    {
        /// <summary>
        /// States that the metric should be in milliseconds.
        /// </summary>
        ISingleBenchmarkOutputBuilder InMilliseconds();

        /// <summary>
        /// States that the metric should be in milliseconds.
        /// </summary>
        ISingleBenchmarkOutputBuilder InTicks();

        /// <summary>
        /// States that the metric should use a custom unit of time selector provider.
        /// </summary>
        /// <param name="provider">The custom unit of time selector provider.</param>
        ISingleBenchmarkOutputBuilder InCustomUnitOfTime(IDataSelectorProvider provider);

        /// <summary>
        /// States that the metric should use a custom unit of time selector provider.
        /// </summary>
        /// <param name="selector">The custom data selector.</param>
        /// <param name="unitOfMeasurement">The unit of measurement of the custom data selector.</param>
        ISingleBenchmarkOutputBuilder InCustomUnitOfTime(Func<TimeSpan, long> selector, string unitOfMeasurement);
    }
}