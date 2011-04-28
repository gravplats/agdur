using System.Collections.Generic;
using Agdur.Abstractions;

namespace Agdur.Internals
{
    /// <summary>
    /// Provides functionality for formatting output of multiple samples.
    /// </summary>
    public class SamplesFormatter : IMetricFormatter
    {
        private static readonly IDictionary<int, string> NumberToWordMap = new Dictionary<int, string>();
        
        private readonly int numberOfSamples;
        private readonly IEnumerable<long> samples;

        static SamplesFormatter()
        {
            NumberToWordMap = new Dictionary<int, string>
            {
                { 2, "two"}, { 3, "three"}, { 4, "four"}, { 5, "five"}, { 6, "six"}, { 7, "seven"}, { 8, "eight"}, { 9, "nine"}, { 10, "ten"}
            };
        }

        /// <summary>
        /// Creates a new instance of the <see cref="SamplesFormatter"/> class.
        /// </summary>
        /// <param name="numberOfSamples">The number of samples; "cached" since we're dealing with an <see cref="IEnumerable&lt;T&gt;"/></param>
        /// <param name="samples">The samples.</param>
        public SamplesFormatter(int numberOfSamples, IEnumerable<long> samples)
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
                string word = ConvertNumberToWord(numberOfSamples);
                return string.Format("The {0} {1} values are {2} {3}.", nameOfMetric, word, ToString(), unitOfMeasurement);
            }

            return string.Format("The {0} value is {1} {2}.", nameOfMetric, ToString(), unitOfMeasurement);
        }

        private static string ConvertNumberToWord(int numberOfSamples)
        {
            string word;
            if (NumberToWordMap.TryGetValue(numberOfSamples, out word))
            {
                return word;
            }

            return numberOfSamples.ToString();
        }
    }
}