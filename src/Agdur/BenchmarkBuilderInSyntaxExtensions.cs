using Agdur.Abstractions;
using System;

namespace Agdur
{
    public static class BenchmarkBuilderInSyntaxExtensions
    {
        /// <summary>
        /// States that the metric should be in milliseconds.
        /// </summary>
        public static TOutput InMilliseconds<TOutput>(this IBenchmarkBuilderInSyntax<TOutput> builder)
        {
            return builder.InCustom(span => Math.Round(span.TotalMilliseconds, MidpointRounding.AwayFromZero), "ms");
        }

        /// <summary>
        /// States that the metric should be in milliseconds.
        /// </summary>
        public static TOutput InTicks<TOutput>(this IBenchmarkBuilderInSyntax<TOutput> builder)
        {
            return builder.InCustom(span => span.Ticks, "ticks");
        }
    }
}