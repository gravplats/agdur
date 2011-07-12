using System.Collections.Generic;

namespace Agdur.IO
{
    /// <summary>
    /// Format a multiple value result.
    /// </summary>
    public static class MultipleValueFormatter
    {
        public static string Output(string name, IList<string> values, string unitOfMeasurement)
        {
            string result = string.Join(", ", values);

            int numberOfSamples = values.Count;
            if (numberOfSamples > 1)
            {
                string word = NumberToStringMapper.GetWordOrDefault(numberOfSamples);
                return string.Format("The {0} {1} values are {2} {3}.", name, word, result, unitOfMeasurement);
            }

            return string.Format(SingleValueFormatter.OutputMessage, name, result, unitOfMeasurement);
        }
    }
}