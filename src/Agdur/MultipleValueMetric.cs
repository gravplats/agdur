using System;
using System.Collections.Generic;
using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// Defines a multiple value metric.
    /// </summary>
    public class MultipleValueMetric : MetricBase
    {
        private readonly Func<IEnumerable<double>, IEnumerable<double>> func;

        /// <summary>
        /// Creates a new instance of the <see cref="MultipleValueMetric"/> class.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        /// <param name="func">The metric.</param>
        public MultipleValueMetric(string name, Func<IEnumerable<double>, IEnumerable<double>> func)
            : base(name)
        {
            this.func = func;
        }

        /// <inheritdoc/>
        public override void Accept(IMetricVisitor visitor)
        {
            visitor.Visit(this);
        }

        /// <inheritdoc/>
        public override IEnumerable<double> GetValues()
        {
            var data = GetData();
            return func(data);
        }
    }
}