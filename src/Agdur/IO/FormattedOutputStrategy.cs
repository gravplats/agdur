using System.Collections.Generic;
using System.IO;
using Agdur.Abstractions;

namespace Agdur.IO
{
    public class FormattedOutputStrategy : IOutputStrategy
    {
        public void Execute(TextWriter writer, IList<IMetric> metrics)
        {
            var visitor = new FormattedOutputMetricVisitor(writer);
            metrics.Accept(visitor);
        }
    }
}