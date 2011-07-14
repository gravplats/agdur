using System.Collections.Generic;
using Agdur.IO;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests.IO
{
    public class FormattedOutputStrategyTests : OutputStrategyContext
    {
        [Fact]
        public void Can_produce_formatted_output()
        {
            var outputStrategy = new FormattedOutputStrategy();
            string result = GetOutput(outputStrategy);

            result.ShouldBe(string.Format("{0}\r\n{1}\r\n",
                SingleValueFormatter.Output("single", "ticks", "100"),
                MultipleValueFormatter.Output("multiple", "ticks", new List<string> { "50", "75" })
            ));
        }
    }
}