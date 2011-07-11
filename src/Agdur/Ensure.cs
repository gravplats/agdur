using System;

namespace Agdur
{
    /// <summary>
    /// Provides functionality for ensuring the proper value of arguments and properties.
    /// </summary>
    public static class Ensure
    {
        /// <summary>
        /// Ensure that the argument is not null.
        /// </summary>
        /// <param name="obj">The argument that should not be null.</param>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="message">The message that should be displayed if the argument is null.</param>
        public static void ArgumentNotNull(object obj, string paramName, string message = "Cannot be null.")
        {
            if (obj == null) throw new ArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Ensure that the property is not null.
        /// </summary>
        /// <param name="obj">The property that should not be null.</param>
        /// <param name="message">The message that should be displayed if the argument is null.</param>
        public static void NotNull(object obj, string message)
        {
            if (obj == null) throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Ensure that the value is greater than zero.
        /// </summary>
        /// <param name="value">The value that should be greater than zero.</param>
        /// <param name="paramName">The name of the parameter.</param>
        public static void GreaterThanZero(int value, string paramName)
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(paramName, "Must be greater than 0.");
        }
    }
}