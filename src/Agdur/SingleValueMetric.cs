using System;
using System.Collections.Generic;
using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// Defines a single value metric.
    /// </summary>
    public class SingleValueMetric : IMetric
    {
        private readonly Func<IEnumerable<double>, double> metric;

        /// <summary>
        /// Creates a new instance of the <see cref="SingleValueMetric"/> class.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        /// <param name="metric">The metric.</param>
        public SingleValueMetric(string name, Func<IEnumerable<double>, double> metric)
        {
            Name = name;
            this.metric = metric;
        }

        /// <inheritdoc/>
        public Func<TimeSpan, IConvertible> DataProvider { get; set; }

        /// <inheritdoc/>
        public string Name { get; private set; }

        /// <inheritdoc/>
        public IEnumerable<TimeSpan> Samples { get; set; }

        /// <inheritdoc/>
        public string UnitOfMeasurement { get; set; }

        /// <inheritdoc/>
        public void Accept(IMetricVisitor visitor)
        {
            visitor.Visit(this);
        }

        public string GetValue()
        {
            var data = Samples.GetData(DataProvider);
            double value = metric(data);

            return value.ToString();
        }
    }
}