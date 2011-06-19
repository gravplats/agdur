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
            var samples = new List<TimeSpan> { new TimeSpan(0, 0, 0, 0, milliseconds: 1) };

            var result = new Metric("test", data => new SingleValueFormatter(data.Max()), samples)
            {
                DataProvider = span => span.Milliseconds
            };

            Should.NotThrow(() => result.GetResult());
        }

        [Fact]
        public void ShouldThrowExceptionIfNoDataSelector()
        {
            TimeSpan span = new TimeSpan(ticks: 1);
            var samples = new List<TimeSpan> { span };

            var result = new Metric("test", data => new SingleValueFormatter(data.Max()), samples)
            {
                DataProvider = null
            };

            Should.Throw<InvalidOperationException>(() => result.GetResult());
        }
    }
}