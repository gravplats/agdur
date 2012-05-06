using NUnit.Framework;

namespace Agdur.Tests
{
    public class XmlOutputStrategyTests : OutputStrategyTestBase
    {
        [Test]
        public void Should_be_able_to_generate_output_as_xml()
        {
            string result = BuildOutputUsing(new XmlOutputStrategy());

            Assert.That(result, Is.EqualTo("<?xml version=\"1.0\" encoding=\"utf-16\"?><benchmark><single>100</single><multiple index=\"0\">50</multiple><multiple index=\"1\">75</multiple></benchmark>"));
        }
    }
}