using System;
using System.Collections.Generic;

namespace FlatSquares
{
	/// <summary>
	/// Define a scene.
	/// </summary>
	public interface IScene : IDisposable, IInitialize, IUpdate, IDraw
	{
		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
		string Key { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:FlatSquares.IScene"/> need to be loaded.
		/// </summary>
		/// <value><c>true</c> if need to be loaded; otherwise, <c>false</c>.</value>
		bool NeedToBeLoaded { get; set; }

		/// <summary>
		/// Gets or sets the nodes.
		/// </summary>
		/// <value>The nodes.</value>
		IEnumerable<INode> Nodes { get; set; }
	}
}
