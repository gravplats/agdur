using System.IO;
using Agdur.Abstractions;

namespace Agdur.IO
{
    /// <summary>
    /// Provides pretty output of the results of a metric.
    /// </summary>
    public class FormattedOutputMetricVisitor : IMetricVisitor
    {
        private readonly TextWriter writer;

        /// <summary>
        /// Creates a new instance of the <see cref="FormattedOutputMetricVisitor"/> class.
        /// </summary>
        /// <param name="writer">A writer</param>
        public FormattedOutputMetricVisitor(TextWriter writer)
        {
            this.writer = writer;
        }

        public void Visit(SingleValueMetric metric)
        {
            string result = SingleValueFormatter.Output(metric.Name, metric.GetValue(), metric.UnitOfMeasurement);
            writer.WriteLine(result);
        }

        public void Visit(MultipleValueMetric metric)
        {
            string result = MultipleValueFormatter.Output(metric.Name, metric.GetValues(), metric.UnitOfMeasurement);
            writer.WriteLine(result);
        }
    }
}