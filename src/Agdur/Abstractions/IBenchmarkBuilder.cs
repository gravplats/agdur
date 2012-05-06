namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the number of times the action to be benchmarked should be run.
    /// </summary>
    public interface IBenchmarkBuilder : IFluentSyntax
    {
        /// <summary>
        /// Specifies that the action should be run once.
        /// </summary>
        IBenchmarkBuilderInSyntax<ISingleBenchmarkBuilderContinuation> Once();

        /// <summary>
        /// Specifies the number of times that the action to be benchmarked should be run.
        /// </summary>
        /// <param name="numberOfTimes">The number of times that the action to be benchmarked should be run.</param>
        IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> Times(int numberOfTimes);
    }
}