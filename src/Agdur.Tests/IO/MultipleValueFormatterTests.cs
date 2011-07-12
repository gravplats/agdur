using System.Linq;
using Agdur.IO;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests.IO
{
    public class MultipleValueFormatterTests
    {
        [Fact]
        public void CanReturnProperOutputForOnlyOneSample()
        {
            var values = Enumerable.Range(1, 1).Select(value => value.ToString()).ToList();
            string result = MultipleValueFormatter.Output("first", values, "ms");

            string expected = string.Format(SingleValueFormatter.OutputMessage, "first", 1, "ms");
            result.ShouldBe(expected);
        }

        [Fact]
        public void CanReturnProperOutputForNumberLessThanTen()
        {
            var values = Enumerable.Range(1, 9).Select(value => value.ToString()).ToList();
            string result = MultipleValueFormatter.Output("first", values, "ms");
            
            string expected = string.Format("The first nine values are {0} ms.", string.Join(", ", values));
            result.ShouldBe(expected);
        }

        [Fact]
        public void CanReturnProperOutputForNumbersGreaterThanNine()
        {
            var values = Enumerable.Range(1, 10).Select(value => value.ToString()).ToList();
            string result = MultipleValueFormatter.Output("first", values, "ms");

            result.ShouldBe("The first 10 values are 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ms.");
        }
    }
}