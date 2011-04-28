namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the number of times the action to be benchmarked should be run.
    /// </summary>
    public interface IBenchmarkRepetitionBuilder : IFluentSyntax
    {
        /// <summary>
        /// Specifies the number of times that the action to be benchmarked should be run.
        /// </summary>
        /// <param name="numberOfTimes">The number of times that the action to be benchmarked should be run.</param>
        IBenchmarkMetricBuilder Times(int numberOfTimes);
    }
}