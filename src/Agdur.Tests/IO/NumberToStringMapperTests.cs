using Agdur.IO;
using NUnit.Framework;

namespace Agdur.Tests.IO
{
    public class NumberToStringMapperTests
    {
        [TestCase(1, "one")]
        [TestCase(2, "two")]
        [TestCase(3, "three")]
        [TestCase(4, "four")]
        [TestCase(5, "five")]
        [TestCase(6, "six")]
        [TestCase(7, "seven")]
        [TestCase(8, "eight")]
        [TestCase(9, "nine")]
        public void If_value_is_between_one_and_nine_should_return_word(int number, string word)
        {
            string result = NumberToStringMapper.GetWordOrDefault(number);
            Assert.That(result, Is.EqualTo(word));
        }

        public void If_value_is_greater_than_or_equal_to_ten_should_return_number()
        {
            string result = NumberToStringMapper.GetWordOrDefault(10);
            Assert.That(result, Is.EqualTo("10"));
        }
    }
}