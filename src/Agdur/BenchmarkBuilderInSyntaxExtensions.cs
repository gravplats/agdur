using Agdur.Abstractions;

namespace Agdur
{
    public static class BenchmarkBuilderInSyntaxExtensions
    {
        /// <summary>
        /// States that the metric should be in milliseconds.
        /// </summary>
        public static TOutput InMilliseconds<TOutput>(this IBenchmarkBuilderInSyntax<TOutput> builder)
        {
            return builder.InCustom(span => span.Milliseconds, "ms");
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