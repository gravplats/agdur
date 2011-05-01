using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests
{
    public class SingleValueFormatterTests
    {
        [Fact]
        public void CanGetOutput()
        {
            var formatter = new SingleValueFormatter(1);
            string result = formatter.GetOutput("test", "ms");

            string expected = string.Format(SingleValueFormatter.OutputMessage, "test", 1, "ms");
            result.ShouldBe(expected);
        }
    }
}