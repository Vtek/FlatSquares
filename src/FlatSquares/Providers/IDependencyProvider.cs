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

        /// <summary>
        /// Inject dependencies in the specified obj.
        /// </summary>
        /// <returns>The inject.</returns>
        /// <param name="obj">Object.</param>
        void Inject(object obj);
    }
}
