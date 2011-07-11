namespace Agdur.Abstractions
{
    public interface IBenchmarkBuilderAsSyntax
    {
        /// <summary>
        /// Uses the specified visitor to display the results of the metrics.
        /// </summary>
        /// <param name="visitor">The visitor that should be used to display the results of the metrics.</param>
        void AsCustom(OutputStrategyBase visitor);
    }
}