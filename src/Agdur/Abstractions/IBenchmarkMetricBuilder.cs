using System;
using System.Collections.Generic;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the type of metric.
    /// </summary>
    /// <typeparam name="TOutput">The type of the output builder.</typeparam>
    public interface IBenchmarkMetricBuilder<out TOutput> : IFluentSyntax
    {
        /// <summary>
        /// Specifies that the average value should be calculated.
        /// </summary>
        IBenchmarkMeasurementBuilder<TOutput> Average();

        /// <summary>
        /// Specifies that the value of the custom metric should be calculated.
        /// </summary>
        /// <param name="nameOfMetric">The name of the custom metric.</param>
        /// <param name="metricFunc">The custom metric.</param>
        IBenchmarkMeasurementBuilder<TOutput> Custom(string nameOfMetric, Func<IEnumerable<long>, IMetricFormatter> metricFunc);

        /// <summary>
        /// Specifies that the first number of specified samples should be displayed.
        /// </summary>
        /// <param name="numberOfSamples">The number of samples that should be displayed.</param>
        IBenchmarkMeasurementBuilder<TOutput> First(int numberOfSamples);

        /// <summary>
        /// Specifies that the maximum value should be calculated.
        /// </summary>
        IBenchmarkMeasurementBuilder<TOutput> Max();

        /// <summary>
        /// Specifies that the minimum value should be calculated.
        /// </summary>
        IBenchmarkMeasurementBuilder<TOutput> Min();

        /// <summary>
        /// Specifies that the total value should be calculated.
        /// </summary>
        IBenchmarkMeasurementBuilder<TOutput> Total();
    }
}