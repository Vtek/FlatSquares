using System;
using FlatSquares.Common;

namespace FlatSquares
{
	/// <summary>
	/// Define a FlatSquares application.
	/// </summary>
	public interface IApplication : IDisposable, IDraw, IUpdate, IInitialize
	{
		/// <summary>
		/// Occurs when started.
		/// </summary>
		event EventHandler Started;

		/// <summary>
		/// Start the application.
		/// </summary>
		void Start<TRoot>() where TRoot : IScene;

		/// <summary>
		/// Define basic game scene.
		/// </summary>
		IApplication Define<TSplash, TLoading>()
			where TSplash : ISplash
			where TLoading : IScene;

        /// <summary>
        /// Apply the specified configuration.
        /// </summary>
        /// <returns>The apply.</returns>
        /// <param name="configuration">Configuration.</param>
        void Apply(Configuration configuration);
	}
}