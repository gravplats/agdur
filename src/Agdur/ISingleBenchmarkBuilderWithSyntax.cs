namespace Agdur
{
    /// <summary>
    /// Used to define the type of metric.
    /// </summary>
    /// /// <typeparam name="TOutput">The type of the output builder.</typeparam>
    public interface ISingleBenchmarkBuilderWithSyntax<out TOutput> : IFluentSyntax
    {
        /// <summary>
        /// Specifies that the single value of the sample should be displayed.
        /// </summary>
        /// <param name="value">An optional custom name for the metric.</param>
        IBenchmarkBuilderInSyntax<TOutput> Value(string value = null);
    }
}