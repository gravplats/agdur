using System;
using System.IO;
using NUnit.Framework;

namespace Agdur.Tests.IO
{
    public class PathGeneratorTests
    {
        [Test]
        public void If_path_contains_absolute_path_should_return_path()
        {
            string path = "c:\\absolute\\filename";
            string result = PathGenerator.Generate(path);

            Assert.That(result, Is.EqualTo(path));
        }

        [Test]
        public void If_path_contains_filename_should_append_path()
        {
            string filename = "filename";
            string result = PathGenerator.Generate(filename);

            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string expected = Path.Combine(directory, filename);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}