using System;

namespace FlatSquares
{
	/// <summary>
	/// Define a FlatSquares application.
	/// </summary>
	public interface IApplication<TRoot, TLoading, TSplash> : IDisposable, IDraw, IUpdate
		where TRoot : IScene 
		where TLoading : IScene
		where TSplash : ISplash
	{
		/// <summary>
		/// Start the application.
		/// </summary>
		void Start();
	}
}
