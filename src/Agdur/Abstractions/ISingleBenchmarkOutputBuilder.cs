namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define how the output should be presented.
    /// </summary>
    public interface ISingleBenchmarkOutputBuilder : ISingleBenchmarkMetricBuilder<ISingleBenchmarkOutputBuilder>, IBenchmarkVisitorBuilder { }
}