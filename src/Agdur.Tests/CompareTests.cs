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
            string xml = "<?xml version=\"1.0\" encoding=\"utf-16\"?><benchmark><average>0</average></benchmark>";
            var reader = new StringReader(xml);

            Compare.This(() => new object()).ToBaseline<BenchmarkProfile>(reader);
        }

        public class BenchmarkProfile : IBenchmarkProfile
        {
            public IBenchmarkBuilderContinutation Define(IBenchmarkBuilder builder)
            {
                return builder.Times(10)
                    .Average().InMilliseconds();
            }
        }
    }
}