using System.Collections.Generic;
using Agdur.Abstractions;
using Agdur.Internals;

namespace Agdur
{
    /// <summary>
    /// Format a multiple value result.
    /// </summary>
    public class MultipleValueFormatter : IMetricFormatter
    {
        private readonly int numberOfSamples;
        private readonly IEnumerable<long> samples;

        /// <summary>
        /// Creates a new instance of the <see cref="MultipleValueFormatter"/> class.
        /// </summary>
        /// <param name="numberOfSamples">The number of samples; "cached" since we're dealing with an <see cref="IEnumerable&lt;T&gt;"/></param>
        /// <param name="samples">The samples.</param>
        public MultipleValueFormatter(int numberOfSamples, IEnumerable<long> samples)
        {
            this.numberOfSamples = numberOfSamples;
            this.samples = samples;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Join(", ", samples);
        }

        /// <inheritdoc/>
        public string GetOutput(string nameOfMetric, string unitOfMeasurement)
        {
            if (numberOfSamples > 1)
            {
                string word = NumberToStringMapper.GetWordOrDefault(numberOfSamples);
                return string.Format("The {0} {1} values are {2} {3}.", nameOfMetric, word, ToString(), unitOfMeasurement);
            }

            return string.Format("The {0} value is {1} {2}.", nameOfMetric, ToString(), unitOfMeasurement);
        }
    }
}