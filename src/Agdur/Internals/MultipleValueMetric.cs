using System;
using System.Collections.Generic;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    public class MultipleValueMetric : MetricBase
    {
        private readonly Func<IEnumerable<double>, IEnumerable<double>> func;

        public MultipleValueMetric(string name, Func<IEnumerable<double>, IEnumerable<double>> func)
            : base(name)
        {
            this.func = func;
        }

        public override void Accept(IMetricVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override IEnumerable<double> GetValues()
        {
            var data = GetData();
            return func(data);
        }
    }
}