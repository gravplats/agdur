using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests
{
    public class SimpleMetricFormatterTests
    {
        [Fact]
        public void CanGetOutput()
        {
            var formatter = new SimpleMetricFormatter(1);
            string result = formatter.GetOutput("test", "ms");

            result.ShouldBe("test: 1 ms");
        }
    }
}