using System;
using System.Collections.Generic;
using FlatSquares.Common;

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
        string Key { get; }

        /// <summary>
        /// Gets the scene.
        /// </summary>
        /// <value>The scene.</value>
        IScene Scene { get; }

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>The components.</value>
        ICollection<IComponent> Components { get; }

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
        /// Gets or sets the position.
        /// </summary>
        /// <value>The position.</value>
        Vector Position { get; set; }

        /// <summary>
        /// Gets the component.
        /// </summary>
        /// <returns>The component.</returns>
        /// <typeparam name="TComponent">The 1st type parameter.</typeparam>
        TComponent GetComponent<TComponent>() where TComponent : IComponent;

        /// <summary>
        /// Add the component.
        /// </summary>
        /// <param name="component">Component.</param>
        void AddComponent(IComponent component);
    }
}
