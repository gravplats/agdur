using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// Provides pretty output of the results of a metric.
    /// </summary>
    public class FormattedOutputMetricVisitor : IMetricVisitor
    {
        private readonly Action<string> write;

        /// <summary>
        /// Creates a new instance of the <see cref="FormattedOutputMetricVisitor"/> class.
        /// </summary>
        /// <param name="write">A writer.</param>
        public FormattedOutputMetricVisitor(Action<string> write)
        {
            this.write = write;
        }

        /// <inheritdoc/>
        public void Visit(SingleValueMetric metric)
        {
            string result = SingleValueFormatter.Output(metric);
            write(result);
        }

        /// <inheritdoc/>
        public void Visit(MultipleValueMetric metric)
        {
            string result = MultipleValueFormatter.Output(metric);
            write(result);
        }
    }
}