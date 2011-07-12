using System;
using System.Collections.Generic;
using System.Linq;
using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// Defines a multiple value metric.
    /// </summary>
    public class MultipleValueMetric : IMetric
    {
        private readonly Func<IEnumerable<double>, IEnumerable<double>> metric;

        /// <summary>
        /// Creates a new instance of the <see cref="MultipleValueMetric"/> class.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        /// <param name="metric">The metric.</param>
        public MultipleValueMetric(string name, Func<IEnumerable<double>, IEnumerable<double>> metric)
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

        public IList<string> GetValues()
        {
            var data = Samples.GetData(DataProvider);
            var values = metric(data);

            return values.Select(value => value.ToString()).ToList();
        }
    }
}