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
        /// Gets or sets the components.
        /// </summary>
        /// <value>The components.</value>
        [Obsolete]
        ICollection<IComponent> Components { get; } //TODO component collection can't be public

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
    }
}
