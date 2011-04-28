using System.IO;
using System.Linq;
using Agdur.Abstractions;
using Agdur.Internals;
using Xunit;

namespace Agdur.Tests
{
    public class BenchmarkTests
    {
        [Fact]
        public void CanBenchmarkAverage()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .Average().InMilliseconds()
                .Average().InTicks();

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkCustom()
        {
            var builder = Benchmark.This(() => new object()).Times(10)
                .Custom("first-five", data => new SamplesFormatter(5, data.Take(5))).InMilliseconds()
                .Custom("first-five", data => new SamplesFormatter(5, data.Take(5))).InTicks();
            
            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkMax()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .Max().InMilliseconds()
                .Max().InTicks();

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkMin()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .Min().InMilliseconds()
                .Min().InTicks();

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkTotal()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .Total().InMilliseconds()
                .Total().InTicks();

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkWithProfile()
        {
            Benchmark.This(() => new object()).With<BenchmarkProfile>();
        }

        public class BenchmarkProfile : IBenchmarkProfile
        {
            public void Define(IBenchmarkRepetitionBuilder builder)
            {
                builder.Times(10000).Average().InMilliseconds().ToConsole();
            }
        }
    }
}