﻿using System;
using System.Collections.Generic;

namespace FlatSquares
{
    /// <summary>
    /// Define a scene.
    /// </summary>
    public interface IScene : IEnabled, IDisposable, IInitialize
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
        /// Create the scene with specified parameters.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        void Create(object parameters = null);

        /// <summary>
        /// Create a node.
        /// </summary>
        /// <returns>The created node.</returns>
        /// <param name="key">Node key.</param>
        INode CreateNode(string key);

        /// <summary>
        /// Gets a node corresponding to a key.
        /// </summary>
        /// <returns>The node.</returns>
        /// <param name="key">Key.</param>
        INode GetNode(string key);

        /// <summary>
        /// Gets nodes corresponding to a tag.
        /// </summary>
        /// <returns>The nodes.</returns>
        /// <param name="tag">Tag.</param>
        IEnumerable<INode> GetNodes(string tag);

        /// <summary>
        /// Remove a node corresponding to a key.
        /// </summary>
        /// <param name="key">Key.</param>
        void RemoveNode(string key);

        /// <summary>
        /// Gets the renderables.
        /// </summary>
        /// <value>The renderables.</value>
        IEnumerable<IRender> Renderables { get; }

        /// <summary>
        /// Gets the updatables.
        /// </summary>
        /// <value>The updatables.</value>
        IEnumerable<IUpdate> Updatables { get; }
    }
}
