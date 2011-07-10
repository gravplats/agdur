using System;
using Agdur.Abstractions;

namespace Agdur
{
    public static class Compare
    {
        public static ICompareBuilder This(Action action)
        {
            var builder = Benchmark.This(action);
            return new CompareBuilder(builder);
        }
    }
}