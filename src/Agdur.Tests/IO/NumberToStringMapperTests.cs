using Agdur.IO;
using Agdur.Tests.Utilities;
using Xunit.Extensions;

namespace Agdur.Tests.IO
{
    public class NumberToStringMapperTests
    {
        [Theory]
        [InlineData(1, "one")]
        [InlineData(2, "two")]
        [InlineData(3, "three")]
        [InlineData(4, "four")]
        [InlineData(5, "five")]
        [InlineData(6, "six")]
        [InlineData(7, "seven")]
        [InlineData(8, "eight")]
        [InlineData(9, "nine")]
        public void ShouldSpellOutSingleDigitWholeNumbers(int number, string word)
        {
            string result = NumberToStringMapper.GetWordOrDefault(number);
            result.ShouldBe(word);
        }

        public void ShouldUseNumberalsForNumbersGreaterThanNine()
        {
            string result = NumberToStringMapper.GetWordOrDefault(10);
            result.ShouldBe("10");
        }
    }
}