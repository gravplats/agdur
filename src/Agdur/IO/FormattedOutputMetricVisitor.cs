using System.IO;
using Agdur.Abstractions;
using Agdur.Introspection;

namespace Agdur.IO
{
    /// <summary>
    /// Provides formatted output of the results of a metric.
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
            Ensure.ArgumentNotNull(writer, "writer");
            this.writer = writer;
        }

        /// <inheritdoc/>
        public void Visit(SingleValueMetric metric)
        {
            Ensure.ArgumentNotNull(metric, "metric");

            string result = SingleValueFormatter.Output(metric.Name, metric.UnitOfMeasurement, metric.GetValue());
            writer.WriteLine(result);
        }

        /// <inheritdoc/>
        public void Visit(MultipleValueMetric metric)
        {
            Ensure.ArgumentNotNull(metric, "metric");

            string result = MultipleValueFormatter.Output(metric.Name, metric.UnitOfMeasurement, metric.GetValues());
            writer.WriteLine(result);
        }
    }
}