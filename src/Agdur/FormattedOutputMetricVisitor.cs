using System.Collections.Generic;
using System.IO;

namespace Agdur
{
    /// <summary>
    /// Provides pretty output of the results of a metric.
    /// </summary>
    public class FormattedOutputMetricVisitor : MetricVisitorBase
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

        protected override void HandleSingleValueMetric(string name, string value, string unitOfMeasurement)
        {
            string result = SingleValueFormatter.Output(name, value, unitOfMeasurement);
            writer.WriteLine(result);
        }

        protected override void HandleMultipleValueMetric(string name, IList<string> values, string unitOfMeasurement)
        {
            string result = MultipleValueFormatter.Output(name, values, unitOfMeasurement);
            writer.WriteLine(result);
        }
    }
}