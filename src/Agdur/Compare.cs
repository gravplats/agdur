using System;
using Agdur.Abstractions;
using Agdur.Internals;

namespace Agdur
{
    public static class Compare
    {
        public static ICompareBuilder This(Action action)
        {
            return new CompareBuilder();
        }
    }
}