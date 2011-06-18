using System;

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

        /// <summary>
        /// States that the metric should use a custom unit of time selector provider.
        /// </summary>
        /// <param name="provider">The custom unit of time selector provider.</param>
        IBenchmarkOutputBuilder InCustomUnitOfTime(IDataSelectorProvider provider);

        /// <summary>
        /// States that the metric should use a custom unit of time selector provider.
        /// </summary>
        /// <param name="selector">The custom data selector.</param>
        /// <param name="unitOfMeasurement">The unit of measurement of the custom data selector.</param>
        IBenchmarkOutputBuilder InCustomUnitOfTime(Func<Sample, long> selector, string unitOfMeasurement);
    }
}