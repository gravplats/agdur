namespace Agdur.Abstractions
{
    /// <summary>
    /// Provides functionality for defining a reusable benchmark baseline profile.
    /// </summary>
    public interface IBenchmarkBaselineProfile
    {
        /// <summary>
        /// Defines the profile
        /// </summary>
        /// <param name="builder">The builder on which the profile should be defined.</param>
        IBenchmarkBuilderContinutation Define(IBenchmarkRepetitionBuilder builder);
    }
}