using System;
using Xunit;

namespace Agdur.Tests.Utilities
{
    public static class Should
    {
        public static void NotThrow(Action action)
        {
            Assert.DoesNotThrow(new Assert.ThrowsDelegate(action));
        }

        public static void Throw<TException>(Action action)
            where TException : Exception
        {
            Assert.Throws<TException>(new Assert.ThrowsDelegate(action));
        }
    }
}