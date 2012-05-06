using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Agdur.Tests.IO
{
    public abstract class OutputStrategyTestBase
    {
        protected static string BuildOutputUsing(IOutputStrategy outputStrategy)
        {
            var single = new SingleValueMetric("single", data => data.Sum())
            {
                DataProvider = sample => sample.Ticks,
                Samples = new List<TimeSpan> { new TimeSpan(100) },
                UnitOfMeasurement = "ticks"
            };

            var multiple = new MultipleValueMetric("multiple", data => data)
            {
                DataProvider = sample => sample.Ticks,
                Samples = new List<TimeSpan> { new TimeSpan(50), new TimeSpan(75) },
                UnitOfMeasurement = "ticks"
            };

            var metrics = new List<IMetric> { single, multiple };

            using (var writer = new StringWriter())
            {
                outputStrategy.Execute(writer, metrics);
                return writer.ToString();
            }
        }
    }
}