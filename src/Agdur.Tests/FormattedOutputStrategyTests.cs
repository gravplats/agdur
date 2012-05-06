using System.Collections.Generic;
using NUnit.Framework;

namespace Agdur.Tests
{
    public class FormattedOutputStrategyTests : OutputStrategyTestBase
    {
        [Test]
        public void Should_be_able_to_generate_output_as_formatted_text()
        {
            string result = BuildOutputUsing(new FormattedOutputStrategy());

            Assert.That(result, Is.EqualTo(string.Format("{0}\r\n{1}\r\n",
                SingleValueFormatter.Output("single", "ticks", "100"),
                MultipleValueFormatter.Output("multiple", "ticks", new List<string> { "50", "75" })
            )));
        }
    }
}