using System.Diagnostics;

namespace Agdur
{
    /// <summary>
    /// Represents a sample for the benchmark.
    /// </summary>
    [DebuggerDisplay("{ToDebuggerDisplay(), nq}")]
    public class Sample
    {
        /// <summary>
        /// Creates a new instance of the <see cref="Sample"/> class.
        /// </summary>
        /// <param name="milliseconds">The sample in milliseconds.</param>
        /// <param name="ticks">The sample in ticks.</param>
        public Sample(long milliseconds, long ticks)
        {
            Milliseconds = milliseconds;
            Ticks = ticks;
        }

        /// <summary>
        /// Returns the sample in milliseconds.
        /// </summary>
        public long Milliseconds { get; private set; }
 
        /// <summary>
        /// Returns the sample in ticks.
        /// </summary>
        public long Ticks { get; private set; }

        // ReSharper disable UnusedMember.Local
        private string ToDebuggerDisplay()
        // ReSharper restore UnusedMember.Local
        {
            return string.Format("Milliseconds: {0}, Ticks {1}", Milliseconds, Ticks);
        }
    }
}