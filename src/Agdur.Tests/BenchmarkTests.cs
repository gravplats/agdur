using System;
using System.IO;
using System.Linq;
using Agdur.Abstractions;
using Agdur.Tests.Utilities;
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
                .Custom("custom", data => new SimpleMetricFormatter(data.Sum())).InMilliseconds()
                .Custom("custom", data => new SimpleMetricFormatter(data.Sum())).InTicks();

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkFirst()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .First(1).InMilliseconds()
                .First(1).InTicks();

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
        public void CanBenchmarkOnce()
        {
            var builder = Benchmark.This(() => new object()).Once()
                .Value().InMilliseconds()
                .Value().InTicks();

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkWithCustomUnitOfTimeUsingLambda()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .Total().InCustomUnitOfTime(sample => sample.Seconds, "s");

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkWithProfile()
        {
            Benchmark.This(() => new object()).With<BenchmarkProfile>();
        }

        [Fact]
        public void CanSetCustomBenchmarkAlgorithmProvider()
        {
            bool wasCalled = false;
            Benchmark.SetBenchmarkAlgorithmProvider(action =>
            {
                wasCalled = true;
                return new DefaultBenchmarkAlgorithm(action);
            });

            Benchmark.This(() => new object());

            wasCalled.ShouldBeTrue();
        }

        [Fact]
        public void CanBenmarchWithFuncProfile()
        {
            Action<IBenchmarkRepetitionBuilder> profile = builder => builder.Times(10000).Average().InMilliseconds().ToConsole();
            Benchmark.This(() => new object()).With(profile);
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