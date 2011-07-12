using System.Collections.Generic;
using Agdur.Abstractions;

namespace Agdur
{
    public static class MetricsExtensions
    {
        public static void Accept(this IEnumerable<IMetric> metrics, IMetricVisitor visitor)
        {
            foreach (var metric in metrics)
            {
                metric.Accept(visitor);
            }
        }
    }
}