using NUnit.Framework;

namespace Agdur.Tests
{
    public class XmlOutputStrategyTests : OutputStrategyTestBase
    {
        [Test]
        public void Should_be_able_to_generate_output_as_xml()
        {
            string result = BuildOutputUsing(new XmlOutputStrategy());

            string xml = 
                "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
                "<benchmark>\r\n" +
                "  <single>100</single>\r\n" +
                "  <multiple index=\"0\">50</multiple>\r\n" +
                "  <multiple index=\"1\">75</multiple>\r\n" +
                "</benchmark>";

            Assert.That(result, Is.EqualTo(xml));
        }
    }
}