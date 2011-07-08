using System.Linq;
using Agdur.Abstractions;

namespace Agdur
{
    /// <summary>
    /// Formats a single value result.
    /// </summary>
    public static class SingleValueFormatter
    {
        /// <summary>
        /// The output message for a single value result.
        /// </summary>
        public static string OutputMessage = "The {0} value is {1} {2}.";

        public static string Output(IMetric metric)
        {
            double value = metric.GetValues().Single();
            return string.Format(OutputMessage, metric.Name, value, metric.UnitOfMeasurement);
        }
    }
}