using System;
using System.IO;

namespace Agdur
{
    public static class PathGenerator
    {
        public static string Generate(string filenameOrPath)
        {
            Ensure.NotNullOrEmpty(filenameOrPath, "filenameOrPath", "Please specify a valid path or filename");

            if (Path.IsPathRooted(filenameOrPath))
            {
                return filenameOrPath;
            }

            string filename = filenameOrPath;
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine(directory, filename);
        }
    }
}