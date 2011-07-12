using System.Collections.Generic;
using System.IO;
using Agdur.Abstractions;
using Agdur.Introspection;

namespace Agdur.IO
{
    /// <summary>
    /// Provides functionality for outputting the results as formatted text.
    /// </summary>
    public class FormattedOutputStrategy : IOutputStrategy
    {
        /// <inheritdoc/>
        public void Execute(TextWriter writer, IList<IMetric> metrics)
        {
            Ensure.ArgumentNotNull(writer, "writer");
            Ensure.ArgumentNotNull(metrics, "metrics");

            var visitor = new FormattedOutputMetricVisitor(writer);
            metrics.Accept(visitor);
        }
    }
}