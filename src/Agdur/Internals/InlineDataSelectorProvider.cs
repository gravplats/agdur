using System;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// Inline data selector provider.
    /// </summary>
    internal class InlineDataSelectorProvider : IDataSelectorProvider
    {
        private readonly Func<TimeSpan, long> selector;
        private readonly string unitOfMeasurement;

        public InlineDataSelectorProvider(Func<TimeSpan, long> selector, string unitOfMeasurement)
        {
            this.selector = selector;
            this.unitOfMeasurement = unitOfMeasurement;
        }

        public Func<TimeSpan, long> GetDataSelector()
        {
            return selector;
        }

        public string GetUnitOfMeasurement()
        {
            return unitOfMeasurement;
        }
    }
}