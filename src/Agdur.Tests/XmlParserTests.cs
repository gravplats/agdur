using System;
using Agdur.Tests.Utilities;
using Xunit;

namespace Agdur.Tests
{
    public class XmlParserTests
    {
        [Fact]
        public void CanParseSingleValueMetric()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><benchmark><average>0</average></benchmark>";
            var collection = XmlParser.Parse(xml);

            collection.Count.ShouldBe(1);
            collection["average"].ShouldBe(0);
        }

        [Fact]
        public void CanParseMultipleValueMetric()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><benchmark><first index=\"0\">0</first><first index=\"1\">1</first></benchmark>";
            var collection = XmlParser.Parse(xml);

            collection.Count.ShouldBe(2);
            collection["first-0"].ShouldBe(0);
            collection["first-1"].ShouldBe(1);
        }

        [Fact]
        public void ShouldFailIfTwoMetricsShareTheSameName()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><benchmark><average>0</average><average>0</average></benchmark>";
            Should.Throw<InvalidOperationException>(() => XmlParser.Parse(xml));
        }
    }
}