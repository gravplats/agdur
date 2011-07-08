using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    public class XmlMetricOutputVisitor : IMetricOutputVisitor
    {
        public void Visit(SingleValueMetric metric)
        {
            throw new NotImplementedException();
        }

        public void Visit(MultipleValueMetric metric)
        {
            throw new NotImplementedException();
        }
    }
}