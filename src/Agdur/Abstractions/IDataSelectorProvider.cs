using System;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Provides functionality for providing a data selector.
    /// </summary>
    public interface IDataSelectorProvider
    {
        /// <summary>
        /// Returns a data selector.
        /// </summary>
        /// <returns>A data selector.</returns>
        Func<TimeSpan, long> GetDataSelector();

        /// <summary>
        /// Returns the unit of measurement associated with the data selector.
        /// </summary>
        /// <returns>The unit of measurement.</returns>
        string GetUnitOfMeasurement();
    }
}