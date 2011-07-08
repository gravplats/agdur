using System;
using System.Collections.Generic;

namespace Agdur.Abstractions
{
    public interface IMetric
    {
        Func<TimeSpan, IConvertible> DataProvider { get; set; }

        string Name { get; }

        IEnumerable<TimeSpan> Samples { get; set; }

        string UnitOfMeasurement { get; set; }

        void Accept(IMetricOutputVisitor visitor);

        IEnumerable<double> GetValues();
    }
}