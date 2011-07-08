using System.Linq;
using Agdur.Abstractions;
using Agdur.Internals;

namespace Agdur
{
    /// <summary>
    /// Format a multiple value result.
    /// </summary>
    public static class MultipleValueFormatter
    {
        public static string Output(IMetric metric)
        {
            var values = metric.GetValues();
            string result = string.Join(", ", values);

            int numberOfSamples = values.Count();
            if (numberOfSamples > 1)
            {
                string word = NumberToStringMapper.GetWordOrDefault(numberOfSamples);
                return string.Format("The {0} {1} values are {2} {3}.", metric.Name, word, result, metric.UnitOfMeasurement);
            }

            return string.Format(SingleValueFormatter.OutputMessage, metric.Name, result, metric.UnitOfMeasurement);
        }
    }
}