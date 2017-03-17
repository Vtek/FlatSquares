using System;

namespace FlatSquares.Providers
{
    /// <summary>
    /// Dependency provider.
    /// </summary>
    public interface IDependencyProvider : IDisposable
    {
        /// <summary>
        /// Gets an instances.
        /// </summary>
        /// <returns>Instance corresponding to a T type.</returns>
        TType GetInstance<TType>();
    }
}
