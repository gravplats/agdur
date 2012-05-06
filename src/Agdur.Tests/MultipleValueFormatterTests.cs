using System.Linq;
using NUnit.Framework;

namespace Agdur.Tests
{
    public class MultipleValueFormatterTests
    {
        [Test]
        public void If_single_value_should_fallback_to_single_value_formatting()
        {
            var values = Enumerable.Range(1, 1).Select(value => value.ToString()).ToList();
            string result = MultipleValueFormatter.Output("first", "ms", values);

            string expected = string.Format(SingleValueFormatter.OutputMessage, "first", 1, "ms");
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void If_less_than_ten_values_should_use_word_instead_of_number()
        {
            var values = Enumerable.Range(1, 9).Select(value => value.ToString()).ToList();
            string result = MultipleValueFormatter.Output("first", "ms", values);
            
            string expected = string.Format("The first nine values are {0} ms.", string.Join(", ", values));
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void If_greater_than_or_equal_to_ten_values_should_use_number()
        {
            var values = Enumerable.Range(1, 10).Select(value => value.ToString()).ToList();
            string result = MultipleValueFormatter.Output("first", "ms", values);

            Assert.That(result, Is.EqualTo("The first 10 values are 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ms."));
        }
    }
}