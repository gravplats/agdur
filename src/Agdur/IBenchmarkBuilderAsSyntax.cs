namespace Agdur
{
    public interface IBenchmarkBuilderAsSyntax : IFluentSyntax
    {
        /// <summary>
        /// Uses the specified output strategy to display the results of the metrics.
        /// </summary>
        /// <param name="outputStrategy">The output strategy that should be used to display the results of the metrics.</param>
        void AsCustom(IOutputStrategy outputStrategy);
    }
}