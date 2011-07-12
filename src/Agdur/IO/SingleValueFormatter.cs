namespace Agdur.IO
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

        public static string Output(string name, string value, string unitOfMeasurement)
        {
            return string.Format(OutputMessage, name, value, unitOfMeasurement);
        }
    }
}