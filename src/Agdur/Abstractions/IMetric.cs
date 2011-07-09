using System;
using System.Collections.Generic;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Defines a metric.
    /// </summary>
    public interface IMetric
    {
        /// <summary>
        /// Gets or sets the data provider.
        /// </summary>
        Func<TimeSpan, IConvertible> DataProvider { get; set; }

        /// <summary>
        /// The name of the metric.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the sample data.
        /// </summary>
        IEnumerable<TimeSpan> Samples { get; set; }

        /// <summary>
        /// Gets or sets the unit of measurement.
        /// </summary>
        string UnitOfMeasurement { get; set; }

        /// <summary>
        /// Accepts a visitor.
        /// </summary>
        /// <param name="visitor">The visitor to be accepted.</param>
        void Accept(IMetricVisitor visitor);

        /// <summary>
        /// Gets the values of the metric.
        /// </summary>
        /// <returns>The values of the metric.</returns>
        IEnumerable<double> GetValues();
    }
}