using System;
using System.Collections.Generic;
using Agdur.Abstractions;

namespace Agdur.Tests
{
    public class TestMetric : IMetric
    {
        private readonly IEnumerable<double> values;

        public TestMetric(string name, string unitOfMeasurement, IEnumerable<double> values)
        {
            this.values = values;
            Name = name;
            UnitOfMeasurement = unitOfMeasurement;
        }

        public Func<TimeSpan, IConvertible> DataProvider
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Name { get; private set; }

        public IEnumerable<TimeSpan> Samples
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string UnitOfMeasurement { get; set; }

        public void Accept(IMetricOutputVisitor visitor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<double> GetValues()
        {
            return values;
        }
    }
}