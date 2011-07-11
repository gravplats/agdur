using System;
using System.Collections.Generic;
using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// Defines a single value metric.
    /// </summary>
    public class SingleValueMetric : MetricBase
    {
        private readonly Func<IEnumerable<double>, double> func;

        /// <summary>
        /// Creates a new instance of the <see cref="SingleValueMetric"/> class.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        /// <param name="func">The metric.</param>
        public SingleValueMetric(string name, Func<IEnumerable<double>, double> func)
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
            yield return func(data);
        }
    }
}