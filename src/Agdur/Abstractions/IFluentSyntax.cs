using System;
using System.ComponentModel;

namespace Agdur.Abstractions
{
    /// <summary>
    /// A hack to hide methods defined on <see cref="object"/> for IntelliSense on fluent interfaces.
    /// </summary>
    /// <remarks>
    /// Credit to Daniel Cazzulino.
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IFluentSyntax
    {
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object other);
    }
}