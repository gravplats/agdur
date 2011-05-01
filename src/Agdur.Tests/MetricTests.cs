using System;
using System.Collections.Generic;
using System.Linq;
using Agdur.Abstractions;
using Agdur.Internals;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests
{
    public class MetricTests
    {
        [Fact]
        public void CanGetResult()
        {
            var sample = new Sample(milliseconds: 1, ticks: 2);
            var samples = new List<Sample> { sample };

            var result = new Metric("test", data => new SingleValueFormatter(data.Max()), samples)
            {
                DataSelectorProvider = new MillisecondsDataSelectorProvider()
            };

            string output = result.GetResult();

            string expected = string.Format(SingleValueFormatter.OutputMessage, "test", 1, "ms");
            output.ShouldBe(expected);
        }

        [Fact]
        public void ShouldThrowExceptionIfNoDataSelector()
        {
            var sample = new Sample(milliseconds: 1, ticks: 2);
            var samples = new List<Sample> { sample };

            var result = new Metric("test", data => new SingleValueFormatter(data.Max()), samples)
            {
                DataSelectorProvider = null
            };

            Should.Throw<InvalidOperationException>(() => result.GetResult());
        }

        [Fact]
        public void ShouldUseMetricFormatterMetricReturnsObjectThatImplementsIt()
        {
            var metric = new Metric("test", data => new TestOutput(), Enumerable.Empty<Sample>())
            {
                DataSelectorProvider = new MillisecondsDataSelectorProvider()
            };

            string result = metric.GetResult();
            result.ShouldBe("test output");
        }

        public class TestOutput : IMetricFormatter
        {
            public string GetOutput(string nameOfMetric, string unitOfMeasurement)
            {
                return "test output";
            }
        }
    }
}