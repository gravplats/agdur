using System;
using System.Collections.Generic;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the type of metric.
    /// </summary>
    /// <typeparam name="TOutput">The type of the output builder.</typeparam>
    public interface IBenchmarkBuilderWithSyntax<out TOutput> : IFluentSyntax
    {
        /// <summary>
        /// Specifies how the value of the custom metric should be calculated.
        /// </summary>
        /// <param name="name">The name of the custom metric.</param>
        /// <param name="func">The metric.</param>
        IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> Custom(string name, Func<IEnumerable<double>, double> func);

        /// <summary>
        /// Specifies how the value of the custom metric should be calculated.
        /// </summary>
        /// <param name="name">The name of the custom metric.</param>
        /// <param name="func">The metric.</param>
        IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> Custom(string name, Func<IEnumerable<double>, IEnumerable<double>> func);

        /// <summary>
        /// Specifies how the value of the custom metric should be calculated.
        /// </summary>
        /// <param name="metric">The metric.</param>
        IBenchmarkBuilderInSyntax<TOutput> Custom(IMetric metric);
    }
}