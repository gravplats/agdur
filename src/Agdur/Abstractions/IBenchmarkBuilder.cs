using System;

namespace Agdur.Abstractions
{
    /// <summary>
    /// Used to define the configuration of the benchmark.
    /// </summary>
    public interface IBenchmarkBuilder : IBenchmarkRepetitionBuilder
    {
        /// <summary>
        /// Specifies a predefined profile that should be used for benchmarking and reporting the
        /// result of the benchmark.
        /// </summary>
        /// <typeparam name="TProfile">The profile type.</typeparam>
        void With<TProfile>()
            where TProfile : IBenchmarkProfile, new();

        /// <summary>
        /// Specifies a predefined profile that should be used for benchmarking and reporting the
        /// result of the benchmark.
        /// </summary>
        /// <param name="profile">The profile.</param>
        void With(Action<IBenchmarkRepetitionBuilder> profile);
    }
}