using System;
using FlatSquares.Common;

namespace FlatSquares
{
	/// <summary>
	/// Define a FlatSquares application.
	/// </summary>
	public interface IApplication : IDisposable, IDraw, IUpdate
	{
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
		/// Sets the color for the clear operation.
		/// </summary>
		/// <returns>The clear color.</returns>
		/// <param name="color">Color.</param>
		IApplication SetClearColor(Color color);

		/// <summary>
		/// Sets the content root path.
		/// </summary>
		/// <returns>The content root path.</returns>
		/// <param name="path">Path.</param>
		IApplication SetContentRootPath(string path);

		/// <summary>
		/// Sets the virtual resolution.
		/// </summary>
		/// <returns>The virtual resolution.</returns>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		IApplication SetVirtualResolution(int width, int height);
	}
}