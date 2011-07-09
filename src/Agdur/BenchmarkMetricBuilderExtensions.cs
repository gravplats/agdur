using System.Linq;
using Agdur.Abstractions;
using Agdur.Internals;

namespace Agdur
{
    public static class BenchmarkMetricBuilderExtensions
    {
        /// <summary>
        /// Specifies that the average value should be calculated.
        /// </summary>
        public static IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Average(this IBenchmarkMetricBuilder<IBenchmarkOutputBuilder> builder)
        {
            return builder.Custom("average", data => data.Average());
        }

        /// <summary>
        /// Specifies that the first number of specified samples should be displayed.
        /// </summary>
        /// <param name="numberOfSamples">The number of samples that should be displayed.</param>
        public static IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> First(this IBenchmarkMetricBuilder<IBenchmarkOutputBuilder> builder, int numberOfSamples)
        {
            Ensure.GreaterThanZero(numberOfSamples, "numberOfSamples");
            return builder.Custom("first", data => data.Take(numberOfSamples));
        }

        /// <summary>
        /// Specifies that the maximum value should be calculated.
        /// </summary>
        public static IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Max(this IBenchmarkMetricBuilder<IBenchmarkOutputBuilder> builder)
        {
            return builder.Custom("maximum", data => data.Max());
        }

        /// <summary>
        /// Specifies that the minimum value should be calculated.
        /// </summary>
        public static IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Min(this IBenchmarkMetricBuilder<IBenchmarkOutputBuilder> builder)
        {
            return builder.Custom("minimum", data => data.Min());
        }

        /// <summary>
        /// Specifies that the total value should be calculated.
        /// </summary>
        public static IBenchmarkMeasurementBuilder<IBenchmarkOutputBuilder> Total(this IBenchmarkMetricBuilder<IBenchmarkOutputBuilder> builder)
        {
            return builder.Custom("total", data => data.Sum());
        }
    }
}