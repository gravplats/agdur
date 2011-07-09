using System;
using System.Collections.Generic;
using System.Linq;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    public abstract class MetricBase : IMetric
    {
        protected MetricBase(string name)
        {
            Name = name;
        }

        public Func<TimeSpan, IConvertible> DataProvider { get; set; }
        
        public string Name { get; private set; }
        
        public IEnumerable<TimeSpan> Samples { get; set; }
        
        public string UnitOfMeasurement { get; set; }

        public abstract void Accept(IMetricOutputVisitor visitor);

        public abstract IEnumerable<double> GetValues();

        protected IEnumerable<double> GetData()
        {
            return Samples.Select(DataProvider).Select(convertible => convertible.ToDouble(null));
        }
    }
}