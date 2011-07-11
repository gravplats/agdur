using System;
using System.Collections.Generic;

namespace Agdur.Internals
{
    /// <summary>
    /// Provides pretty output of the results of a metric.
    /// </summary>
    public class FormattedOutputMetricVisitor : MetricVisitorBase
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

        protected override void HandleSingleValueMetric(string name, string value, string unitOfMeasurement)
        {
            string result = SingleValueFormatter.Output(name, value, unitOfMeasurement);
            write(result);
        }

        protected override void HandleMultipleValueMetric(string name, IList<string> values, string unitOfMeasurement)
        {
            string result = MultipleValueFormatter.Output(name, values, unitOfMeasurement);
            write(result);
        }
    }
}