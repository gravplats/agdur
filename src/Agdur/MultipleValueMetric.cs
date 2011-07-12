using System;
using System.Collections.Generic;
using System.Linq;
using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// Defines a multiple value metric.
    /// </summary>
    public class MultipleValueMetric : MetricBase
    {
        private readonly Func<IEnumerable<double>, IEnumerable<double>> metric;

        /// <summary>
        /// Creates a new instance of the <see cref="MultipleValueMetric"/> class.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        /// <param name="metric">The metric.</param>
        public MultipleValueMetric(string name, Func<IEnumerable<double>, IEnumerable<double>> metric)
            : base(name)
        {
            this.metric = metric;
        }

        /// <inheritdoc/>
        public override void Accept(IMetricVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IList<string> GetValues()
        {
            var data = GetData();
            var values = metric(data);

            return values.Select(value => value.ToString()).ToList();
        }
    }
}