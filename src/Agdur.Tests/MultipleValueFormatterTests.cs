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
            
            string output = container.GetOutput("first", "ms");

            output.ShouldBe("The first value is 1 ms.");
        }

        [Fact]
        public void CanReturnProperOutputForNumberLessThanTen()
        {
            var values = Enumerable.Range(1, 9).Select(Convert.ToInt64);
            var container = new MultipleValueFormatter(values.Count(), values);

            string output = container.GetOutput("first", "ms");
            
            string expected = string.Format("The first nine values are {0} ms.", container);
            output.ShouldBe(expected);
        }

        [Fact]
        public void CanReturnProperOutputForNumbersGreaterThanNine()
        {
            var values = Enumerable.Range(1, 10).Select(Convert.ToInt64);
            var container = new MultipleValueFormatter(values.Count(), values);

            string output = container.GetOutput("first", "ms");

            output.ShouldBe("The first 10 values are 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ms.");
        }
    }
}