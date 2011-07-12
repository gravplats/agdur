﻿using System;
using System.Collections.Generic;
using System.Linq;
using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// Provides a base class for metrics.
    /// </summary>
    public abstract class MetricBase : IMetric
    {
        protected MetricBase(string name)
        {
            Name = name;
        }

        /// <inheritdoc/>
        public Func<TimeSpan, IConvertible> DataProvider { get; set; }

        /// <inheritdoc/>
        public string Name { get; private set; }

        /// <inheritdoc/>
        public IEnumerable<TimeSpan> Samples { get; set; }

        /// <inheritdoc/>
        public string UnitOfMeasurement { get; set; }

        /// <inheritdoc/>
        public abstract void Accept(IMetricVisitor visitor);

        protected IEnumerable<double> GetData()
        {
            return Samples.Select(DataProvider).Select(convertible => convertible.ToDouble(null));
        }
    }
}