using System.Collections.Generic;
using System.IO;
using System.Linq;
using Agdur.Abstractions;
using NUnit.Framework;

namespace Agdur.Tests
{
    public class BenchmarkTests
    {
        [Test]
        public void Should_be_able_to_set_custom_benchmark_strategy_provider()
        {
            bool wasCalled = false;
            Benchmark.SetBenchmarkStrategyProvider(action =>
            {
                wasCalled = true;
                return new DefaultBenchmarkStrategy(action);
            });

            Benchmark.This(() => new object());

            Assert.That(wasCalled, Is.True);
        }

        public class BenchmarkProfile : IBenchmarkProfile
        {
            public IBenchmarkBuilderContinutation Define(IBenchmarkBuilder builder)
            {
                return builder.Times(10).Average().InMilliseconds();
            }
        }
    }

    // "Assert" that we don't break the fluent interface for multiple samples '.WithCustom()'.
    public class Should_be_able_to_benchmark_with
    {
        private readonly IBenchmarkBuilderWithSyntax<IBenchmarkBuilderContinutation> tbuilder = 
            Benchmark.This(() => new object()).Times(1);

        [Test]
        public void Custom_metric()
        {
            tbuilder.WithCustom(new MultipleValueMetric("custom", data => data));
        }

        [Test]
        public void Multiple_custom_metrics()
        {
            tbuilder
                .WithCustom("custom", data => data.Sum()).InTicks()
                .WithCustom("custom", data => data.Sum()).InTicks();
        }

        [Test]
        public void Custom_simplified_single_metric()
        {
            tbuilder.WithCustom("custom", data => data.Sum());
        }

        [Test]
        public void Custom_simplified_multiple_metric()
        {
            tbuilder.WithCustom("custom", data => data);
        }

        [Test]
        public void Average()
        {
            tbuilder.Average();
        }

        [Test]
        public void First()
        {
            tbuilder.First(1);
        }

        [Test]
        public void Max()
        {
            tbuilder.Max();
        }

        [Test]
        public void Min()
        {
            tbuilder.Min();
        }

        [Test]
        public void Total()
        {
            tbuilder.Total();
        }
    }

    // "Assert" that we don't break the fluent interface for '.InCustom()'.
    public class Should_be_able_to_benchmark_in
    {
        private readonly IBenchmarkBuilderInSyntax<IBenchmarkBuilderContinutation> tbuilder =
            Benchmark.This(() => new object()).Times(1).WithCustom(new MultipleValueMetric("custom", data => data));

        private readonly IBenchmarkBuilderInSyntax<ISingleBenchmarkBuilderContinuation> obuilder =
            Benchmark.This(() => new object()).Once();

        [Test]
        public void Custom_time()
        {
            tbuilder.InCustom(sample => sample.Seconds, "s");
            obuilder.InCustom(sample => sample.Seconds, "s");
        }

        [Test]
        public void Milliseconds()
        {
            tbuilder.InMilliseconds();
            obuilder.InMilliseconds();
        }

        [Test]
        public void Ticks()
        {
            tbuilder.InTicks();
            obuilder.InTicks();
        }
    }

    // "Assert" that we don't break the fluent interface for '.ToCustom()'.
    public class Should_be_able_to_benchmark_to
    {
        private readonly IBenchmarkBuilderContinutation tbuilder =
            Benchmark.This(() => new object()).Times(1).WithCustom(new SingleValueMetric("custom", data => data.Sum())).InCustom(sample => sample.Seconds, "s");

        private readonly ISingleBenchmarkBuilderContinuation obuilder =
            Benchmark.This(() => new object()).Once().InCustom(sample => sample.Seconds, "s");

        [Test]
        public void Custom()
        {
            tbuilder.ToCustom(new StringWriter());
            obuilder.ToCustom(new StringWriter());
        }

        [Test]
        public void Console()
        {
            tbuilder.ToConsole();
            obuilder.ToConsole();
        }

        [Test]
        public void Path()
        {
            tbuilder.ToPath("filename");
            obuilder.ToPath("filename");
        }
    }

    // "Assert" that we don't break the fluent interface for '.AsCustom()'.
    public class Should_be_able_to_benchmark_as
    {
        private readonly IBenchmarkBuilderAsSyntax tbuilder =
            Benchmark.This(() => new object()).Times(10).WithCustom(new SingleValueMetric("custom", data => data.Sum())).InCustom(sample => sample.Seconds, "s").ToCustom(new StringWriter());

        private readonly IBenchmarkBuilderAsSyntax obuilder =
            Benchmark.This(() => new object()).Once().InCustom(sample => sample.Seconds, "s").ToCustom(new StringWriter());

        [Test]
        public void Custom()
        {
            tbuilder.AsCustom(new CustomOutputStrategy());
            obuilder.AsCustom(new CustomOutputStrategy());
        }

        [Test]
        public void FormattedString()
        {
            tbuilder.AsFormattedString();
            obuilder.AsFormattedString();
        }

        [Test]
        public void Xml()
        {
            tbuilder.AsXml();
            obuilder.AsXml();
        }

        public class CustomOutputStrategy : IOutputStrategy
        {
            public void Execute(TextWriter writer, IList<IMetric> metrics) { }
        }
    }
}