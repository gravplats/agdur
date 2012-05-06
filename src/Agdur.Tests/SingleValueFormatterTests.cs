using NUnit.Framework;

namespace Agdur.Tests
{
    public class SingleValueFormatterTests
    {
        [Test]
        public void Should_able_to_generate_output_for_single_value()
        {
            string result = SingleValueFormatter.Output("test", "ms", "1");

            string expected = string.Format(SingleValueFormatter.OutputMessage, "test", 1, "ms");
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}