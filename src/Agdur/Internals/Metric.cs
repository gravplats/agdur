using System;
using System.Collections.Generic;
using System.Linq;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// Provides functionality for reporting the result of a metric.
    /// </summary>
    public class Metric
    {
        private readonly string nameOfMetric;
        private readonly Func<IEnumerable<double>, IMetricFormatter> metric;
        private readonly IEnumerable<TimeSpan> samples;

        /// <summary>
        /// Creates a new instance of the <see cref="Metric"/> class.
        /// </summary>
        /// <param name="nameOfMetric">The name of the metric.</param>
        /// <param name="metric">The function for calculating the result of the metric.</param>
        /// <param name="samples">The sample data.</param>
        public Metric(string nameOfMetric, Func<IEnumerable<double>, IMetricFormatter> metric, IEnumerable<TimeSpan> samples)
        {
            Ensure.ArgumentNotNull(nameOfMetric, "nameOfMetric");
            Ensure.ArgumentNotNull(metric, "metric");
            Ensure.ArgumentNotNull(samples, "samples");

            this.samples = samples;
            this.nameOfMetric = nameOfMetric;
            this.metric = metric;
        }

        /// <summary>
        /// Gets or sets the data provider.
        /// </summary>
        public Func<TimeSpan, IConvertible> DataProvider { get; set; }

        /// <summary>
        /// Gets or sets the unit of measurement.
        /// </summary>
        public string UnitOfMeasurement { get; set; }

        /// <summary>
        /// Returns the result of the metric.
        /// </summary>
        /// <returns>The result of the metric.</returns>
        public string GetResult()
        {
            Ensure.NotNull(DataProvider, "Internal error: Metric.DataProvider cannot be null.");

            var resultOfMetric = GetResultOfMetric();
            return resultOfMetric.GetOutput(nameOfMetric, GetUnitOfMeasurement());
        }

        private IMetricFormatter GetResultOfMetric()
        {
            var data = samples.Select(DataProvider).Select(convertible => convertible.ToDouble(null));
            return metric(data);
        }

        private string GetUnitOfMeasurement()
        {
            return UnitOfMeasurement ?? "[unknown unit of measurement]";
        }
    }
}