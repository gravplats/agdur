This is the master repository of Agdur, a micro-benchmarking library for .NET. Agdur was inspired by the following [post](http://stackoverflow.com/questions/1507405/c-is-this-benchmarking-class-accurate) on [stackoverflow](http://stackoverflow.com).

The library is named in honor of table hockey player extraordinaire [G&#246;ran Agdur](http://www.youtube.com/watch?v=Z3LY64nCMIU), the benchmark of any aspiring table hockey player.

Syntax
------

Agdur provides an easy-to-use API for benchmarking an operation.

    Benchmark.This(() => new object()).Times(100)
        .Average().InMilliseconds()
	    .Max().InMilliseconds()
	    .Min().InMilliseconds()
	    .ToConsole();