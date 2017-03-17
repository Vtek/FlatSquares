using System;
namespace FlatSquares
{
    /// <summary>
    /// Define an active object
    /// </summary>
    public interface IActive
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:FlatSquares.IActive"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        bool Active { get; }
    }
}
