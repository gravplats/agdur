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
        private readonly Func<IEnumerable<long>, IMetricFormatter> metric;
        private readonly IEnumerable<Sample> samples;
        
        /// <summary>
        /// Creates a new instance of the <see cref="Metric"/> class.
        /// </summary>
        /// <param name="nameOfMetric">The name of the metric.</param>
        /// <param name="metric">The function for calculating the result of the metric.</param>
        /// <param name="samples">The sample data.</param>
        public Metric(string nameOfMetric, Func<IEnumerable<long>, IMetricFormatter> metric, IEnumerable<Sample> samples)
        {
            Ensure.ArgumentNotNull(nameOfMetric, "nameOfMetric");
            Ensure.ArgumentNotNull(metric, "metric");
            Ensure.ArgumentNotNull(samples, "samples");

            this.samples = samples;
            this.nameOfMetric = nameOfMetric;
            this.metric = metric;
        }

        /// <summary>
        /// Gets or set the data selector provider.
        /// </summary>
        public IDataSelectorProvider DataSelectorProvider { get; set; }

        /// <summary>
        /// Returns the result of the metric.
        /// </summary>
        /// <returns>The result of the metric.</returns>
        public string GetResult()
        {
            Ensure.NotNull(DataSelectorProvider, "Internal error: Metric.DataSelectorProvider cannot be null.");

            var resultOfMetric = GetResultOfMetric();
            return resultOfMetric.GetOutput(nameOfMetric, GetUnitOfMeasurement());
        }

        private IMetricFormatter GetResultOfMetric()
        {
            IEnumerable<long> data = samples.Select(DataSelectorProvider.GetDataSelector());
            return metric(data);
        }

        private string GetUnitOfMeasurement()
        {
            return DataSelectorProvider.GetUnitOfMeasurement() ?? "[unknown unit of measurement]";
        }
    }
}