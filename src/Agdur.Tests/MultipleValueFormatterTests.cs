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
            var values = Enumerable.Range(1, 1).Select(Convert.ToInt64);
            var container = new MultipleValueFormatter(values.Count(), values);

            string result = container.GetOutput("first", "ms");

            string expected = string.Format(SingleValueFormatter.OutputMessage, "first", 1, "ms");
            result.ShouldBe(expected);
        }

        [Fact]
        public void CanReturnProperOutputForNumberLessThanTen()
        {
            var values = Enumerable.Range(1, 9).Select(Convert.ToInt64);
            var container = new MultipleValueFormatter(values.Count(), values);

            string result = container.GetOutput("first", "ms");

            string expected = string.Format("The first nine values are {0} ms.", container);
            result.ShouldBe(expected);
        }

        [Fact]
        public void CanReturnProperOutputForNumbersGreaterThanNine()
        {
            var values = Enumerable.Range(1, 10).Select(Convert.ToInt64);
            var container = new MultipleValueFormatter(values.Count(), values);

            string result = container.GetOutput("first", "ms");
            result.ShouldBe("The first 10 values are 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ms.");
        }
    }
}