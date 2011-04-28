using System;
using System.Collections.Generic;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the type of metric.
    /// </summary>
    public interface IBenchmarkMetricBuilder : IFluentSyntax
    {
        /// <summary>
        /// Specifies that the average value should be calculated.
        /// </summary>
        IBenchmarkMeasurementBuilder Average();

        /// <summary>
        /// Specifies that the value of the custom metric should be calculated.
        /// </summary>
        /// <param name="nameOfMetric">The name of the custom metric.</param>
        /// <param name="metricFunc">The custom metric.</param>
        IBenchmarkMeasurementBuilder Custom(string nameOfMetric, Func<IEnumerable<long>, object> metricFunc);

        /// <summary>
        /// Specifies that the first number of specified samples should be displayed.
        /// </summary>
        /// <param name="numberOfSamples">The number of samples that should be displayed.</param>
        IBenchmarkMeasurementBuilder First(int numberOfSamples);

        /// <summary>
        /// Specifies that the maximum value should be calculated.
        /// </summary>
        IBenchmarkMeasurementBuilder Max();

        /// <summary>
        /// Specifies that the minimum value should be calculated.
        /// </summary>
        IBenchmarkMeasurementBuilder Min();

        /// <summary>
        /// Specifies that the total value should be calculated.
        /// </summary>
        IBenchmarkMeasurementBuilder Total();
    }
}