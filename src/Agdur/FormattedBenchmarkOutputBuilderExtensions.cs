using System;
using System.IO;
using Agdur.Abstractions;
using Agdur.Internals;

namespace Agdur
{
    public static class FormattedBenchmarkOutputBuilderExtensions
    {
        /// <summary>
        /// Writes the output to the console.
        /// </summary>
        public static void ToConsole(this IBenchmarkVisitorBuilder builder)
        {
            builder.Write(Console.WriteLine);
        }

        /// <summary>
        /// Writes the output ot the writer.
        /// </summary>
        /// <param name="writer">The writer that the output should be written to.</param>
        public static void ToWriter(this IBenchmarkVisitorBuilder builder, TextWriter writer)
        {
            Ensure.ArgumentNotNull(writer, "writer");
            builder.Write(writer.WriteLine);
        }

        private static void Write(this IBenchmarkVisitorBuilder builder, Action<string> write)
        {
            Ensure.ArgumentNotNull(write, "write");

            var visitor = new FormattedOutputMetricVisitor(write);
            builder.ToVisitor(visitor);
        }
    }
}