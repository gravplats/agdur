using Agdur.IO;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests.IO
{
    public class XmlOutputStrategyTests : OutputStrategyContext
    {
        [Fact]
        public void Can_produce_xml_output()
        {
            var outputStrategy = new XmlOutputStrategy();
            string result = GetOutput(outputStrategy);

            result.ShouldBe("<?xml version=\"1.0\" encoding=\"utf-16\"?><benchmark><single>100</single><multiple index=\"0\">50</multiple><multiple index=\"1\">75</multiple></benchmark>");
        }
    }
}