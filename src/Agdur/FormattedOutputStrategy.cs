using System.Collections.Generic;
using System.IO;
using Agdur.Abstractions;

namespace Agdur
{
    public class FormattedOutputStrategy : OutputStrategyBase
    {
        public override void Execute(TextWriter writer, IList<IMetric> metrics)
        {
            var visitor = new FormattedOutputMetricVisitor(writer);
            Visit(visitor, metrics);
        }
    }
}