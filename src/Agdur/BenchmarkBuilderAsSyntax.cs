using System.Collections.Generic;
using System.IO;

namespace Agdur
{
    /// <summary>
    /// The output builder.
    /// </summary>
    public class BenchmarkBuilderAsSyntax : IBenchmarkBuilderAsSyntax
    {
        private readonly TextWriter writer;
        private readonly IList<IMetric> metrics;

        /// <summary>
        /// Creates a new instance of the <see cref="BenchmarkBuilderAsSyntax"/> class.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="metrics">The metrics that has been defined for the benchmark.</param>
        public BenchmarkBuilderAsSyntax(TextWriter writer, IList<IMetric> metrics)
        {
            Ensure.ArgumentNotNull(writer, "writer");
            Ensure.ArgumentNotNull(metrics, "metrics");

            this.writer = writer;
            this.metrics = metrics;
        }

        /// <summary>
        /// Specifies the output strategy.
        /// </summary>
        /// <param name="output">The output strategy that should be used to generate the output of the benchmark</param>
        public void AsCustom(IOutputStrategy output)
        {
            Ensure.ArgumentNotNull(output, "output");
            output.Execute(writer, metrics);
        }
    }
}