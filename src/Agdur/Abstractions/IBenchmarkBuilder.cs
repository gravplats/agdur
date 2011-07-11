using System.IO;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the configuration of the benchmark.
    /// </summary>
    public interface IBenchmarkBuilder : IBenchmarkRepetitionBuilder
    {
        /// <summary>
        /// Specifies a predefined profile that should be used for creating a baseline.
        /// </summary>
        /// <typeparam name="TProfile">The baseline profile type.</typeparam>
        /// <param name="path">The path that the baseline should be written to.</param>
        void AsBaseline<TProfile>(string path) 
            where TProfile : IBenchmarkBaselineProfile, new();

        /// <summary>
        /// Specifies a predefined profile that should be used for creating a baseline.
        /// </summary>
        /// <typeparam name="TProfile">The baseline profile type.</typeparam>
        /// <param name="writer">The writer that the baseline should be written to.</param>
        void AsBaseline<TProfile>(TextWriter writer)
            where TProfile : IBenchmarkBaselineProfile, new();
    }
}