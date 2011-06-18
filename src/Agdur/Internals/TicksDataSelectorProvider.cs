using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// Provides a selector for selecting the ticks sample.
    /// </summary>
    public class TicksDataSelectorProvider : IDataSelectorProvider
    {
        /// <inheritdoc/>
        public Func<TimeSpan, long> GetDataSelector()
        {
            return sample => sample.Ticks;
        }

        /// <inheritdoc/>
        public string GetUnitOfMeasurement()
        {
            return "ticks";
        }
    }
}