using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    public class StringMetricOutputVisitor : IMetricOutputVisitor
    {
        private readonly Action<string> write;

        public StringMetricOutputVisitor(Action<string> write)
        {
            this.write = write;
        }

        public void Visit(SingleValueMetric metric)
        {
            string result = SingleValueFormatter.Output(metric);
            write(result);
        }

        public void Visit(MultipleValueMetric metric)
        {
            string result = MultipleValueFormatter.Output(metric);
            write(result);
        }
    }
}