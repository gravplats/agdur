using System;
using System.Collections.Generic;
using System.Linq;
using Agdur.Internals;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests.Internals
{
    public class MetricTests
    {
        [Fact]
        public void ShouldNotThrowIfDataSelector()
        {
            var sample = new Sample(milliseconds: 1, ticks: 2);
            var samples = new List<Sample> { sample };

            var result = new Metric("test", data => new SingleValueFormatter(data.Max()), samples)
            {
                DataSelectorProvider = new MillisecondsDataSelectorProvider()
            };

            Should.NotThrow(() => result.GetResult());
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
    }
}