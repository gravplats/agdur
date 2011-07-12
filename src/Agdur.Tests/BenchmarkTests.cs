using System;
using System.Collections.Generic;
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
        public void Should_be_able_to_benchmark_as_baseline_using_writer()
        {
            var writer = new StringWriter();
            Benchmark.This(() => new object()).AsBaseline<BenchmarkProfile>(writer);

            string result = writer.ToString();
            Console.WriteLine(result);
        }

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

        public class BenchmarkProfile : IBenchmarkProfile
        {
            public IBenchmarkBuilderContinutation Define(IBenchmarkBuilder builder)
            {
                return builder.Times(10).Average().InMilliseconds();
            }
        }
    }

    public class Should_be_able_to_benchmark_with
    {
        private readonly IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> builder =
            Benchmark.This(() => new object()).Times(1);

        [Fact]
        public void Custom_metric()
        {
            builder.WithCustom(new MultipleValueMetric("custom", data => data));
        }

        [Fact]
        public void Custom_simplified_single_metric()
        {
            builder.WithCustom("custom", data => data.Sum());
        }

        [Fact]
        public void Custom_simplified_multiple_metric()
        {
            builder.WithCustom("custom", data => data);
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
            Benchmark.This(() => new object()).Times(1).WithCustom(new MultipleValueMetric("custom", data => data));

        [Fact]
        public void Custom_time()
        {
            builder.InCustom(sample => sample.Seconds, "s");
        }

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
    }

    public class Should_be_able_to_benchmark_once_in
    {
        private readonly IBenchmarkBuilderInSyntax<ISingleBenchmarkBuilderContinuation> builder =
            Benchmark.This(() => new object()).Once().Value();

        [Fact]
        public void Custom_time()
        {
            builder.InCustom(sample => sample.Seconds, "s");
        }

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
    }

    public class Should_be_able_to_benchmark_to
    {
        private readonly IBenchmarkBuilderContinutation builder =
            Benchmark.This(() => new object()).Times(10).WithCustom(new SingleValueMetric("custom", data => data.Sum())).InCustom(sample => sample.Seconds, "s");

        [Fact]
        public void Custom()
        {
            builder.ToCustom(new StringWriter());
        }

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
    }

    public class Should_be_able_to_benchmark_as
    {
        private readonly IBenchmarkBuilderAsSyntax builder =
            Benchmark.This(() => new object()).Times(10).WithCustom(new SingleValueMetric("custom", data => data.Sum())).InCustom(sample => sample.Seconds, "s").ToConsole();

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

        public class CustomOutputStrategy : IOutputStrategy
        {
            public void Execute(TextWriter writer, IList<IMetric> metrics) { }
        }
    }
}