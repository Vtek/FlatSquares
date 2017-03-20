using System;
using System.Collections.Generic;
using FlatSquares.Common;

namespace FlatSquares
{
    /// <summary>
    /// Define a node game object
    /// </summary>
    public interface INode : IDisposable, IInitialize, IEnabled
    {
        /// <summary>
        /// Occurs when component added.
        /// </summary>
        event EventHandler<IComponent> ComponentAdded;

        /// <summary>
        /// Occurs when component removed.
        /// </summary>
        event EventHandler<IComponent> ComponentRemoved;

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
        TComponent GetComponent<TComponent>() where TComponent : IComponent;

        /// <summary>
        /// Add the component.
        /// </summary>
        /// <param name="component">Component.</param>
        void AddComponent(IComponent component);

        /// <summary>
        /// Removes the component.
        /// </summary>
        void RemoveComponent<TComponent>() where TComponent : IComponent;

        /// <summary>
        /// Add a tag.
        /// </summary>
        /// <param name="tag">Tag.</param>
        void AddTag(string tag);

        /// <summary>
        /// True if Node is tagged with a specific tag.
        /// </summary>
        /// <returns><c>true</c>, if Node is tagged with a specific tag, <c>false</c> otherwise.</returns>
        /// <param name="tag">Tag.</param>
        bool IsTagged(string tag);
    }
}
