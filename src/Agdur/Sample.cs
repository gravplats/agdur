using System;
using System.Diagnostics;

namespace Agdur
{
    /// <summary>
    /// Represents a sample for the benchmark.
    /// </summary>
    [DebuggerDisplay("{ToDebuggerDisplay(), nq}")]
    public sealed class Sample
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Sample"/> class.
        /// </summary>
        /// <param name="span"></param>
        public Sample(TimeSpan span)
        {
            Span = span;
        }

        /// <summary>
        /// Returns the sample in milliseconds.
        /// </summary>
        public long Milliseconds
        {
            get { return Span.Milliseconds; }
        }

        /// <summary>
        /// Returns the time span of the sample.
        /// </summary>
        public TimeSpan Span { get; private set; }

        /// <summary>
        /// Returns the sample in ticks.
        /// </summary>
        public long Ticks
        {
            get { return Span.Ticks; }
        }

        internal string ToDebuggerDisplay()
        {
            return string.Format("Milliseconds: {0}, Ticks {1}", Milliseconds, Ticks);
        }
    }
}