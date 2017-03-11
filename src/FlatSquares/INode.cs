using System;
using System.Collections.Generic;

namespace FlatSquares
{
	/// <summary>
	/// Define a node game object
	/// </summary>
	public interface INode : IEnabled, IDisposable
	{
		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
		string Key { get; set; }

		/// <summary>
		/// Gets or sets the components.
		/// </summary>
		/// <value>The components.</value>
		IEnumerable<IComponent> Components { get; set; }

		/// <summary>
		/// Gets or sets the scale.
		/// </summary>
		/// <value>The scale.</value>
		float Scale { get; set; }

		/// <summary>
		/// Gets or sets the rotation.
		/// </summary>
		/// <value>The rotation.</value>
		float Rotation { get; set; }

		/// <summary>
		/// Gets or sets the x position.
		/// </summary>
		/// <value>The x.</value>
		float X { get; set; }

		/// <summary>
		/// Gets or sets the y position.
		/// </summary>
		/// <value>The y position.</value>
		float Y { get; set; }
	}
}
