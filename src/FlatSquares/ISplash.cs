using System;

namespace FlatSquares
{
	/// <summary>
	/// Define a splash scene.
	/// </summary>
	public interface ISplash : IScene
	{
		/// <summary>
		/// Occurs when splash scene is finished.
		/// </summary>
		event EventHandler Finished;
	}
}
