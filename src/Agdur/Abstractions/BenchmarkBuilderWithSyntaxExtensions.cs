using System;
using System.Collections.Generic;

namespace Agdur.Abstractions
{
    public static class BenchmarkBuilderWithSyntaxExtensions
    {
        /// <summary>
        /// Specifies how the value of the custom metric should be calculated.
        /// </summary>
        /// <param name="name">The name of the custom metric.</param>
        /// <param name="func">The metric.</param>
        public static IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> WithCustom(this IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder, string name, Func<IEnumerable<double>, double> func)
        {
            return builder.WithCustom(new SingleValueMetric(name, func));
        }

        /// <summary>
        /// Specifies how the value of the custom metric should be calculated.
        /// </summary>
        /// <param name="name">The name of the custom metric.</param>
        /// <param name="func">The metric.</param>
        public static IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> WithCustom(this IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder, string name, Func<IEnumerable<double>, IEnumerable<double>> func)
        {
            return builder.WithCustom(new MultipleValueMetric(name, func));
        }
    }
}