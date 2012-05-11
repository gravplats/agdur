using System;
using System.Collections.Generic;
using System.Linq;

namespace Agdur
{
    public static class BenchmarkBuilderWithSyntaxExtensions
    {
        /// <summary>
        /// Specifies how the value of the custom metric should be calculated.
        /// </summary>
        /// <param name="builder"> </param>
        /// <param name="func">The metric.</param>
        /// <param name="name">The name of the custom metric.</param>
        public static IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> WithCustom(this IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder, Func<IEnumerable<double>, double> func, string name)
        {
            return builder.WithCustom(new SingleValueMetric(name, func));
        }

        /// <summary>
        /// Specifies how the value of the custom metric should be calculated.
        /// </summary>
        /// <param name="builder"> </param>
        /// <param name="func">The metric.</param>
        /// <param name="name">The name of the custom metric.</param>
        public static IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> WithCustom(this IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder, Func<IEnumerable<double>, IEnumerable<double>> func, string name)
        {
            return builder.WithCustom(new MultipleValueMetric(name, func));
        }

        /// <summary>
        /// Specifies that the average value should be calculated.
        /// </summary>
        public static IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> Average(this IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder)
        {
            return builder.WithCustom(data => Enumerable.Average((IEnumerable<double>) data), "average");
        }

        /// <summary>
        /// Specifies that the first number of specified samples should be displayed.
        /// </summary>
        /// <param name="numberOfSamples">The number of samples that should be displayed.</param>
        public static IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> First(this IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder, int numberOfSamples)
        {
            Ensure.GreaterThanZero(numberOfSamples, "numberOfSamples");
            return builder.WithCustom(data => data.Take(numberOfSamples), "first");
        }

        /// <summary>
        /// Specifies that the maximum value should be calculated.
        /// </summary>
        public static IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> Max(this IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder)
        {
            return builder.WithCustom(data => Enumerable.Max((IEnumerable<double>) data), "maximum");
        }

        /// <summary>
        /// Specifies that the minimum value should be calculated.
        /// </summary>
        public static IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> Min(this IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder)
        {
            return builder.WithCustom(data => Enumerable.Min((IEnumerable<double>) data), "minimum");
        }

        /// <summary>
        /// Specifies that the total value should be calculated.
        /// </summary>
        public static IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> Total(this IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder)
        {
            return builder.WithCustom(data => Enumerable.Sum((IEnumerable<double>) data), "total");
        }
    }
}