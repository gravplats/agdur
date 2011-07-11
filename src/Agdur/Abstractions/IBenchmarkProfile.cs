namespace Agdur.Abstractions
{
    /// <summary>
    /// Provides functionality for defining a reusable benchmark profile.
    /// </summary>
    public interface IBenchmarkProfile
    {
        /// <summary>
        /// Defines the profile.
        /// </summary>
        /// <param name="builder">The builder on which the profile should be defined.</param>
        IBenchmarkBuilderContinutation Define(IBenchmarkRepetitionBuilder builder);
    }
}