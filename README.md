Agdur
=====

Agdur is a micro-benchmarking library for the .NET framework.

Credits
-------

Agdur was inspired by the following two posts on [stackoverflow](http://stackoverflow.com):

* [C#: Is this benchmarking class accurate](http://stackoverflow.com/questions/1507405/c-is-this-benchmarking-class-accurate)
* [Benchmarking small code samples in C#, can this implementation be improved](http://stackoverflow.com/questions/1047218/benchmarking-small-code-samples-in-c-can-this-implementation-be-improved)

The library is named in honor of table hockey player extraordinaire [G&#246;ran Agdur](http://www.youtube.com/watch?v=Z3LY64nCMIU), the benchmark of any aspiring table hockey player.

Basic Usage
-----------

Agdur provides an easy-to-use API for benchmarking an operation.

``` csharp
Benchmark.This(() => new object()).Times(100)
    .Average().InMilliseconds()
    .Max().InMilliseconds()
    .Min().InMilliseconds()
    .ToConsole().AsXml();
```

Table of Contents
-----------------

* [Benchmark](#section-benchmark)
* [Metrics](#section-metrics)
* [Output](#section-output)

<a name="section-benchmark"></a>
Benchmark
---------

The `Benchmark` class serves as the main entry point of the benchmarking API. `Benchmark` defines two static methods `This` and `SetBenchmarkStrategyProvider`.

### This

To benchmark an action you use `Benchmark.This(Action action).Times(100)`, where `Times` specifies the number of times that the action should be executed. If you only need to run the action one time you could use the following shortcut `Benchmark.This(() => new object()).Once()`.

### SetBenchmarkStrategyProvider

Agdur is equipped with a default benchmarking strategy which, as previously mentioned, was based on the following two posts on [stackoverflow](http://www.stackoverflow.com):

* [C#: Is this benchmarking class accurate](http://stackoverflow.com/questions/1507405/c-is-this-benchmarking-class-accurate)
* [Benchmarking small code samples in C#, can this implementation be improved?](http://stackoverflow.com/questions/1047218/benchmarking-small-code-samples-in-c-can-this-implementation-be-improved)

If this strategy is insufficient to your needs you could define your own custom benchmarking strategy by implementing `IBenchmarkStrategy`.

``` csharp
public class CustomBenchmarkStrategy : IBenchmarkStrategy
{
    private readonly Action action;

    public CustomBenchmarkStrategy(Action action)
    {
        this.action = action;
    }

    public IEnumerable<TimeSpan> Run(int numberOfTimes)
    {
        // Your custom benchmark strategy.
    }
}
```

Using your custom benchmarking strategy is as simple as

``` csharp
Benchmark.SetBenchmarkStrategyProvider(action => new CustomBenchmarkStrategy(action));
```

<a name="section-metrics"></a>
Metrics
-------

For each benchmark it is possible to choose one or more metrics. Metrics are specified as a continuation of `Times`. You must also specify the unit of time that should be used for each metric.

    Benchmark.This(() => new object())
        .Times(100)
        .Average().InMilliseconds()
        .Max().InTicks()
        .Min.InTicks();

Agdur defines a number of predefined metrics: `Average`, `First`, `Max`, `Min` and `Total`.

If neither of these metrics should suit your needs you can choose to define your own custom metric using any of the `WithCustom` overloads. In fact, all predefined metrics are defined as extension methods of `WithCustom`.

The following example demonstrates how you could define your own custom average metric.

``` csharp
Benchmark.This(() => new object())
    .Times(100)
    .WithCustom("average", data => data.Average());
```

Agdur defines a couple of units of time in which the metrics should be displayed: `InMilliseconds` and `InTicks`.

As is the case for metrics, if neither unit of times should suit your needs you can choose to define your own custom unit of time using `InCustom`. All predefined unit of times are defined as extension methods of `InCustom`.

The following example demonstrates how you could define your own custom unit of time.

``` csharp
Benchmark.This(() => new object())
    .Times(100)
    .Average().InCustom(span => span.Seconds, "s");
```

<a name="section-output"></a>
Output
------

For each benchmark it is possible to choose where to and how the output should be written.

Use `ToConsole` if the output should be written to the console or `ToPath` if the output should be written to a file. Finally, use `ToCustom` if you would like to specify a `TextWriter` of your own choice.

Once you've decided where the output should be written to it is time to decided the format of the output using either `AsFormattedString`, `AsXml` or `AsCustom`.