using System;
using System.Linq;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests
{
    public class MultipleValueFormatterTests
    {
        [Fact]
        public void CanReturnProperOutputForOnlyOneSample()
        {
            var values = Enumerable.Range(1, 1).Select(Convert.ToDouble);
            var metric = new TestMetric("first", "ms", values);

            string result = MultipleValueFormatter.Output(metric);

            string expected = string.Format(SingleValueFormatter.OutputMessage, "first", 1, "ms");
            result.ShouldBe(expected);
        }

        [Fact]
        public void CanReturnProperOutputForNumberLessThanTen()
        {
            var values = Enumerable.Range(1, 9).Select(Convert.ToDouble);
            var metric = new TestMetric("first", "ms", values);

            string result = MultipleValueFormatter.Output(metric);

            string expected = string.Format("The first nine values are {0} ms.", string.Join(", ", values));
            result.ShouldBe(expected);
        }

        [Fact]
        public void CanReturnProperOutputForNumbersGreaterThanNine()
        {
            var values = Enumerable.Range(1, 10).Select(Convert.ToDouble);
            var metric = new TestMetric("first", "ms", values);

            string result = MultipleValueFormatter.Output(metric);
            result.ShouldBe("The first 10 values are 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ms.");
        }
    }
}