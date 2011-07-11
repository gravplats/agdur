using System.Collections.Generic;
using System.Linq;
using Agdur.Abstractions;

namespace Agdur
{
    public abstract class MetricVisitorBase : IMetricVisitor
    {
        /// <inheritdoc/>
        public void Visit(SingleValueMetric metric)
        {
            string value = metric.GetValues().Single().ToString();
            HandleSingleValueMetric(metric.Name, value, metric.UnitOfMeasurement);
        }

        /// <inheritdoc/>
        public void Visit(MultipleValueMetric metric)
        {
            var values = metric.GetValues().Select(value => value.ToString()).ToList();
            HandleMultipleValueMetric(metric.Name, values, metric.UnitOfMeasurement);
        }

        protected abstract void HandleSingleValueMetric(string name, string value, string unitOfMeasurement);

        protected abstract void HandleMultipleValueMetric(string name, IList<string> values, string unitOfMeasurement);
    }
}