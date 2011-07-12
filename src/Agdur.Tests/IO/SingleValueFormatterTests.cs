using Agdur.IO;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests.IO
{
    public class SingleValueFormatterTests
    {
        [Fact]
        public void CanGetOutput()
        {
            string result = SingleValueFormatter.Output("test", "1", "ms");

            string expected = string.Format(SingleValueFormatter.OutputMessage, "test", 1, "ms");
            result.ShouldBe(expected);
        }
    }
}