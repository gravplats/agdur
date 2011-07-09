using System.IO;
using Agdur.Abstractions;
using Xunit;

namespace Agdur.Tests
{
    public class CompareTests
    {
        [Fact]
        public void CanCompareToBaseline()
        {
            var reader = new StringReader("");
            Compare.This(() => new object()).ToBaseline<BenchmarkBaselineProfile>(reader);
        }

        public class BenchmarkBaselineProfile : IBenchmarkBaselineProfile
        {
            public IBenchmarkBaselineBuilder Define(IBenchmarkRepetitionBuilder builder)
            {
                return builder.Times(10)
                    .Average().InMilliseconds()
                    .First(5).InMilliseconds();
            }
        }
    }
}