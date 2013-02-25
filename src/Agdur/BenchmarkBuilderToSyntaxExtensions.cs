using System;

namespace Agdur
{
    public static class BenchmarkBuilderToSyntaxExtensions
    {
        /// <summary>
        /// Writes the output to the console.
        /// </summary>
        public static IBenchmarkBuilderAsSyntax ToConsole(this IBenchmarkBuilderToSyntax builder)
        {
            return builder.ToCustom(Console.Out);
        }

        /// <summary>
        /// Writes the output to the specified path or filename. If a filename or relative path is specified it will be
        /// relative the current base directory of the executing app domain. If the file exists, it will be overwritten.
        /// </summary>
        /// <param name="filenameOrPath"></param>
        public static IBenchmarkBuilderAsSyntax ToPath(this IBenchmarkBuilderToSyntax builder, string filenameOrPath)
        {
            Ensure.NotNullOrEmpty(filenameOrPath, "filenameOrPath", "Please specify a valid path or filename");

            string path = PathGenerator.Generate(filenameOrPath);
            return new PathBenchmarkBuilderAsSyntax(builder, path);
        }
    }
}