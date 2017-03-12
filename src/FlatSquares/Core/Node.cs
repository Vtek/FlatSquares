using System;
using System.Collections.Generic;
using System.Linq;
using FlatSquares.Common;

namespace FlatSquares.Core
{
	/// <summary>
	/// Node game object.
	/// </summary>
	public class Node : INode
	{
		/// <summary>
		/// Gets or sets the components.
		/// </summary>
		/// <value>The components.</value>
		public IEnumerable<IComponent> Components { get; } = new List<IComponent>();

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:FlatSquares.Core.Node"/> is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		public bool Enabled { get; set; } = true;

		/// <summary>
		/// Gets or sets the key.
		/// </summary>
		/// <value>The key.</value>
		public string Key { get; set; }

		/// <summary>
		/// Gets or sets the rotation.
		/// </summary>
		/// <value>The rotation.</value>
		public float Rotation { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>The scale.</value>
        public float Scale { get; set; } = 1f;

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public Vector Position { get; set; } = Vector.Zero;

		/// <summary>
		/// Adds the component.
		/// </summary>
		/// <param name="component">Component.</param>
		public void AddComponent(IComponent component)
		{
			if (Components.Any(c => c.GetType() == component.GetType()))
				throw new ArgumentException();

			component.SetNode(this);
            (Components as IList<IComponent>)?.Add(component);
		}

		/// <summary>
		/// Releases all resource used by the <see cref="T:FlatSquares.Core.Node"/> object.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:FlatSquares.Core.Node"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="T:FlatSquares.Core.Node"/> in an unusable state. After calling
		/// <see cref="Dispose"/>, you must release all references to the <see cref="T:FlatSquares.Core.Node"/> so the garbage
		/// collector can reclaim the memory that the <see cref="T:FlatSquares.Core.Node"/> was occupying.</remarks>
		public void Dispose()
			=>
				Components.ForEach(item => item.Dispose());

		/// <summary>
		/// Gets the component.
		/// </summary>
		/// <returns>The component.</returns>
		/// <typeparam name="TComponent">The 1st type parameter.</typeparam>
		public TComponent GetComponent<TComponent>() where TComponent : IComponent
			=>
				(TComponent)Components.SingleOrDefault(component => component.GetType().FullName == typeof(TComponent).FullName);
	}
}
