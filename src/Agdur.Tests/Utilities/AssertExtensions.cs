using Xunit;

namespace Agdur.Tests.Utilities
{
    public static class AssertExtensions
    {
        public static void ShouldBe<T>(this T actual, T expected)
        {
            Assert.Equal(expected, actual);
        }
    }
}