using System;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the type of measurement that should be used for presenting the metric.
    /// </summary>
    /// <typeparam name="TOutput">The type of the output builder.</typeparam>
    public interface IBenchmarkBuilderInSyntax<out TOutput> : IFluentSyntax
    {
        /// <summary>
        /// States that the metric should be in milliseconds.
        /// </summary>
        TOutput InMilliseconds();

        /// <summary>
        /// States that the metric should be in milliseconds.
        /// </summary>
        TOutput InTicks();

        /// <summary>
        /// States that the metric should use a custom unit of time based on the specified provider.
        /// </summary>
        /// <param name="provider">The custom data provider.</param>
        /// <param name="unitOfMeasurement">The unit of measurement of the custom data selector.</param>
        TOutput InCustom(Func<TimeSpan, IConvertible> provider, string unitOfMeasurement);
    }
}