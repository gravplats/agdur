using System.Collections.Generic;
using System.IO;
using Agdur.Abstractions;

namespace Agdur
{
    public abstract class OutputStrategyBase
    {
        public abstract void Execute(TextWriter writer, IList<IMetric> metrics);

        protected void Visit(IMetricVisitor visitor, IList<IMetric> metrics)
        {
            foreach (var metric in metrics)
            {
                metric.Accept(visitor);
            }
        }
    }
}