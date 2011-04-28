using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// Provides a selector for selecting the milliseconds sample.
    /// </summary>
    public class MillisecondsDataSelectorProvider : IDataSelectorProvider
    {
        /// <inheritdoc/>
        public Func<Sample, long> GetDataSelector()
        {
            return sample => sample.Milliseconds;
        }

        /// <inheritdoc/>
        public string GetUnitOfMeasurement()
        {
            return "ms";
        }
    }
}