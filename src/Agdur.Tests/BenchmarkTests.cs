using System;
using System.Collections.Generic;
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
        public void Should_be_able_to_benchmark_as_baseline_using_writer()
        {
            var writer = new StringWriter();
            Benchmark.This(() => new object()).AsBaseline<BenchmarkBaselineProfile>(writer);

            string result = writer.ToString();
            Console.WriteLine(result);
        }

        //[Fact]
        //public void Should_be_able_to_benchmark_with_profile()
        //{
        //    Benchmark.This(() => new object()).With<BenchmarkProfile>();
        //}

        //[Fact]
        //public void Should_be_able_to_benchmark_with_func_profile()
        //{
        //    Action<IBenchmarkRepetitionBuilder> profile = builder => builder.Times(10000).Average().InMilliseconds().ToConsole();
        //    Benchmark.This(() => new object()).With(profile);
        //}

        [Fact]
        public void Should_be_able_to_set_custom_benchmark_strategy_provider()
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

        //public class BenchmarkProfile : IBenchmarkProfile
        //{
        //    public void Define(IBenchmarkRepetitionBuilder builder)
        //    {
        //        builder.Times(10000).Average().InMilliseconds().ToConsole();
        //    }
        //}

        public class BenchmarkBaselineProfile : IBenchmarkBaselineProfile
        {
            public IBenchmarkBuilderContinutation Define(IBenchmarkRepetitionBuilder builder)
            {
                return builder.Times(10)
                    .Average().InMilliseconds();
            }
        }
    }

    public class Should_be_able_to_benchmark_using
    {
        private readonly IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder =
            Benchmark.This(() => new object()).Times(1);

        [Fact]
        public void Custom_metric()
        {
            builder.Custom(new MultipleValueMetric("custom", data => data));
        }

        [Fact]
        public void Custom_simplified_single_metric()
        {
            builder.Custom("custom", data => data.Sum());
        }

        [Fact]
        public void Custom_simplified_multiple_metric()
        {
            builder.Custom("custom", data => data);
        }

        [Fact]
        public void Average()
        {
            builder.Average();
        }

        [Fact]
        public void First()
        {
            builder.First(1);
        }

        [Fact]
        public void Max()
        {
            builder.Max();
        }

        [Fact]
        public void Min()
        {
            builder.Min();
        }

        [Fact]
        public void Total()
        {
            builder.Total();
        }
    }

    public class Should_be_able_to_benchmark_in
    {
        private readonly IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> builder =
            Benchmark.This(() => new object()).Times(1).Custom(new MultipleValueMetric("custom", data => data));

        [Fact]
        public void Milliseconds()
        {
            builder.InMilliseconds();
        }

        [Fact]
        public void Ticks()
        {
            builder.InTicks();
        }

        [Fact]
        public void Custom_time()
        {
            builder.InCustom(sample => sample.Seconds, "s");
        }
    }

    public class Should_be_able_to_benchmark_once_in
    {
        private readonly IBenchmarkBuilderInSyntax<ISingleBenchmarkBuilderContinuation> builder =
            Benchmark.This(() => new object()).Once().Value();

        [Fact]
        public void Milliseconds()
        {
            builder.InMilliseconds();
        }

        [Fact]
        public void Ticks()
        {
            builder.InTicks();
        }

        [Fact]
        public void Custom_time()
        {
            builder.InCustom(sample => sample.Seconds, "s");
        }
    }

    public class Should_be_able_to_benchmark_to
    {
        private readonly IBenchmarkBuilderContinutation builder =
            Benchmark.This(() => new object()).Times(10).Custom(new SingleValueMetric("custom", data => data.Sum())).InCustom(sample => sample.Seconds, "s");

        [Fact]
        public void Console()
        {
            builder.ToConsole();
        }

        [Fact]
        public void Path()
        {
            builder.ToPath("");
        }

        [Fact]
        public void Writer()
        {
            builder.ToCustom(new StringWriter());
        }
    }

    public class Should_be_able_to_benchmark_as
    {
        private readonly IBenchmarkBuilderAsSyntax builder =
            Benchmark.This(() => new object()).Times(10).Custom(new SingleValueMetric("custom", data => data.Sum())).InCustom(sample => sample.Seconds, "s").ToCustom(new StringWriter());

        [Fact]
        public void Custom()
        {
            builder.AsCustom(new CustomOutputStrategy());
        }

        [Fact]
        public void FormattedString()
        {
            builder.AsFormattedString();
        }

        [Fact]
        public void Xml()
        {
            builder.AsXml();
        }
    }

    public class CustomOutputStrategy : OutputStrategyBase
    {
        public override void Execute(TextWriter writer, IList<IMetric> metrics) { }
    }
}