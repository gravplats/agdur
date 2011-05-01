using System;
using System.Linq;
using Agdur.Internals;
using Agdur.Tests.Utilities;
using Xunit;
using Xunit.Extensions;

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

        [Theory]
        [InlineData(2, "two")]
        [InlineData(3, "three")]
        [InlineData(4, "four")]
        [InlineData(5, "five")]
        [InlineData(6, "six")]
        [InlineData(7, "seven")]
        [InlineData(8, "eight")]
        [InlineData(9, "nine")]
        [InlineData(10, "ten")]
        public void CanReturnProperOutputForTwoSamples(int number, string word)
        {
            var values = Enumerable.Range(1, number).Select(Convert.ToInt64);
            var container = new MultipleValueFormatter(values.Count(), values);

            string output = container.GetOutput("first", "ms");
            
            string expected = string.Format("The first {0} values are {1} ms.", word, container);
            output.ShouldBe(expected);
        }

        [Fact]
        public void CanReturnProperOutputForElevenSamples()
        {
            var values = Enumerable.Range(1, 11).Select(Convert.ToInt64);
            var container = new MultipleValueFormatter(values.Count(), values);

            string output = container.GetOutput("first", "ms");

            output.ShouldBe("The first 11 values are 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 ms.");
        }
    }
}