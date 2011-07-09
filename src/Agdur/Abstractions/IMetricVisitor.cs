using Agdur.Internals;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Provides functionality for visiting a metric.
    /// </summary>
    public interface IMetricVisitor
    {
        /// <summary>
        /// Visits a single value metric.
        /// </summary>
        /// <param name="metric">The metric that should be visited</param>
        void Visit(SingleValueMetric metric);

        /// <summary>
        /// Visits a multiple value metric.
        /// </summary>
        /// <param name="metric">The metric that should be visited.</param>
        void Visit(MultipleValueMetric metric);
    }
}