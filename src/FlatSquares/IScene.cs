using System;
using System.Collections.Generic;

namespace FlatSquares
{
    /// <summary>
    /// Define a scene.
    /// </summary>
    public interface IScene : IDisposable, IEnabled
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
        IList<INode> Nodes { get; }

        /// <summary>
        /// Create the scene with specified parameters.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        void Create(object parameters = null);

        /// <summary>
        /// Gets the initializables.
        /// </summary>
        /// <returns>The initializables.</returns>
        IEnumerable<IInitialize> GetInitializables();

        /// <summary>
        /// Gets the renderables.
        /// </summary>
        /// <returns>The renderable.</returns>
        IEnumerable<IRender> GetRenderables();

        /// <summary>
        /// Gets the loadables.
        /// </summary>
        /// <returns>The loadables.</returns>
        IEnumerable<ILoad> GetLoadables();

        /// <summary>
        /// Gets the loadables.
        /// </summary>
        /// <returns>The loadables.</returns>
        IEnumerable<IUpdate> GetUpdatables();
    }
}
