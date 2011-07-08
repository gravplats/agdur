using System;
using System.Collections.Generic;
using System.Linq;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    public class SingleValueMetric : IMetric
    {
        private readonly Func<IEnumerable<double>, double> func;

        public SingleValueMetric(string name, Func<IEnumerable<double>, double> func)
        {
            Name = name;
            this.func = func;
        }

        public Func<TimeSpan, IConvertible> DataProvider { get; set; }

        public string Name { get; private set; }

        public IEnumerable<TimeSpan> Samples { get; set; }

        public string UnitOfMeasurement { get; set; }

        public void Accept(IMetricOutputVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IEnumerable<double> GetValues()
        {
            var data = Samples.Select(DataProvider).Select(convertible => convertible.ToDouble(null));
            yield return func(data);
        }
    }
}