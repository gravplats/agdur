using System.IO;
using Agdur.Abstractions;
using Agdur.Introspection;

namespace Agdur
{
    public static class BenchmarkBuilderExtensions
    {
        /// <summary>
        /// Specifies a predefined profile that should be used for creating a baseline.
        /// </summary>
        /// <typeparam name="TProfile">The baseline profile type.</typeparam>
        /// <param name="path">The path that the baseline should be written to.</param>
        public static void AsBaseline<TProfile>(this IBenchmarkBuilder builder, string path)
            where TProfile : IBenchmarkProfile, new()
        {
            var profile = new TProfile();
            profile.Define(builder).ToPath(path).AsXml();            
        }

        /// <summary>
        /// Specifies a predefined profile that should be used for creating a baseline.
        /// </summary>
        /// <typeparam name="TProfile">The baseline profile type.</typeparam>
        /// <param name="writer">The writer that the baseline should be written to.</param>
        public static void AsBaseline<TProfile>(this IBenchmarkBuilder builder, TextWriter writer)
            where TProfile : IBenchmarkProfile, new()
        {
            Ensure.ArgumentNotNull(writer, "writer");

            var profile = new TProfile();
            profile.Define(builder).ToCustom(writer).AsXml();
        }
    }
}