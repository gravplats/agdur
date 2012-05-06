namespace Agdur
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
        /// <param name="metric">The metric.</param>
        IBenchmarkBuilderInSyntax<TOutput> WithCustom(IMetric metric);
    }
}