using System.Collections.Generic;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests
{
    public class SingleValueFormatterTests
    {
        [Fact]
        public void CanGetOutput()
        {
            string result = SingleValueFormatter.Output(new TestMetric("test", "ms", new List<double> { 1 }));

            string expected = string.Format(SingleValueFormatter.OutputMessage, "test", 1, "ms");
            result.ShouldBe(expected);
        }
    }
}