using System;
using System.IO;
using System.Linq;
using Agdur.Abstractions;
using Agdur.Internals;
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
                .Average().InTicks()
                .Average().InCustom(sample => sample.Seconds, "s");

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkCustom()
        {
            var builder = Benchmark.This(() => new object()).Times(10)
                .Custom(new SingleValueMetric("custom", data => data.Sum())).InMilliseconds()
                .Custom(new SingleValueMetric("custom", data => data.Sum())).InTicks()
                .Custom(new SingleValueMetric("custom", data => data.Sum())).InCustom(sample => sample.Seconds, "s");

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkFirst()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .First(1).InMilliseconds()
                .First(1).InTicks()
                .First(1).InCustom(sample => sample.Seconds, "s");

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkMax()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .Max().InMilliseconds()
                .Max().InTicks()
                .Max().InCustom(sample => sample.Seconds, "s");

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkMin()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .Min().InMilliseconds()
                .Min().InTicks()
                .Min().InCustom(sample => sample.Seconds, "s");

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkTotal()
        {
            var builder = Benchmark.This(() => new object()).Times(1)
                .Total().InMilliseconds()
                .Total().InTicks()
                .Total().InCustom(sample => sample.Seconds, "s");

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkOnce()
        {
            var builder = Benchmark.This(() => new object()).Once()
                .Value().InMilliseconds()
                .Value().InTicks()
                .Value().InCustom(sample => sample.Seconds, "s");

            builder.ToConsole();
            builder.ToWriter(new StringWriter());
        }

        [Fact]
        public void CanBenchmarkAsBaselineUsingWriter()
        {
            var writer = new StringWriter();
            Benchmark.This(() => new object()).AsBaseline<BenchmarkBaselineProfile>(writer);
            
            string result = writer.ToString();
            Console.WriteLine(result);
        }

        [Fact]
        public void CanBenchmarkWithProfile()
        {
            Benchmark.This(() => new object()).With<BenchmarkProfile>();
        }

        [Fact]
        public void CanBenmarchWithFuncProfile()
        {
            Action<IBenchmarkRepetitionBuilder> profile = builder => builder.Times(10000).Average().InMilliseconds().ToConsole();
            Benchmark.This(() => new object()).With(profile);
        }

        [Fact]
        public void CanSetCustomBenchmarkAlgorithmProvider()
        {
            bool wasCalled = false;
            Benchmark.SetBenchmarkStrategyProvider(action =>
            {
                wasCalled = true;
                return new DefaultBenchmarkStrategy(action);
            });

            Benchmark.This(() => new object());

            wasCalled.ShouldBeTrue();
        }

        public class BenchmarkProfile : IBenchmarkProfile
        {
            public void Define(IBenchmarkRepetitionBuilder builder)
            {
                builder.Times(10000).Average().InMilliseconds().ToConsole();
            }
        }

        public class BenchmarkBaselineProfile : IBenchmarkBaselineProfile
        {
            public IBenchmarkOutputBuilder Define(IBenchmarkRepetitionBuilder builder)
            {
                return builder.Times(10)
                    .Average().InMilliseconds();
            }
        }
    }
}