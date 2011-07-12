using System.Collections.Generic;
using System.IO;
using Agdur.Abstractions;

namespace Agdur
{
    public class BenchmarkBuilderAsSyntax : IBenchmarkBuilderAsSyntax
    {
        private readonly TextWriter writer;
        private readonly IList<IMetric> metrics;

        public BenchmarkBuilderAsSyntax(TextWriter writer, IList<IMetric> metrics)
        {
            this.writer = writer;
            this.metrics = metrics;
        }

        public void AsCustom(IOutputStrategy output)
        {
            output.Execute(writer, metrics);
        }
    }
}