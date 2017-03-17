using System;
using Autofac;
using FlatSquares.Providers;

namespace FlatSquares.MonoGame.Dependencies
{
    /// <summary>
    /// Dependency container.
    /// </summary>
    class DependencyProvider : IDependencyProvider
    {
        /// <summary>
        /// Gets the lifetime scope.
        /// </summary>
        /// <value>The lifetime scope.</value>
        ILifetimeScope LifetimeScope { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FlatSquares.MonoGame.DependencyContainer"/> class.
        /// </summary>
        /// <param name="lifetimeScope">Lifetime scope.</param>
        public DependencyProvider(ILifetimeScope lifetimeScope)
        {
            LifetimeScope = lifetimeScope;
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:FlatSquares.MonoGame.DependencyContainer"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="T:FlatSquares.MonoGame.DependencyContainer"/>. The <see cref="Dispose"/> method leaves the
        /// <see cref="T:FlatSquares.MonoGame.DependencyContainer"/> in an unusable state. After calling
        /// <see cref="Dispose"/>, you must release all references to the
        /// <see cref="T:FlatSquares.MonoGame.DependencyContainer"/> so the garbage collector can reclaim the memory
        /// that the <see cref="T:FlatSquares.MonoGame.DependencyContainer"/> was occupying.</remarks>
        public void Dispose() => LifetimeScope.Dispose();

        /// <summary>
        /// Gets an instance corresponding to a type
        /// </summary>
        /// <returns>The instance.</returns>
        public TType GetInstance<TType>() => LifetimeScope.Resolve<TType>();

        /// <summary>
        /// Inject dependencies in the specified obj.
        /// </summary>
        /// <returns>The inject.</returns>
        /// <param name="obj">Object.</param>
        public void Inject(object obj) => LifetimeScope.InjectProperties(obj);
    }
}