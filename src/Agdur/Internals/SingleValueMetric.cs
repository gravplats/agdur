using System;
using System.Collections.Generic;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    public class SingleValueMetric : MetricBase
    {
        private readonly Func<IEnumerable<double>, double> func;

        public SingleValueMetric(string name, Func<IEnumerable<double>, double> func)
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
            yield return func(data);
        }
    }
}