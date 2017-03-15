using System;
using System.Collections.Generic;
using System.Linq;

namespace FlatSquares.Core
{
    /// <summary>
    /// Scene.
    /// </summary>
    public abstract class Scene : IScene
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:FlatSquares.Core.Scene"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:FlatSquares.Scene"/> need to be loaded.
        /// </summary>
        /// <value><c>true</c> if need to be loaded; otherwise, <c>false</c>.</value>
        public bool NeedToBeLoaded { get; set; } = false;

        /// <summary>
        /// Gets or sets the nodes.
        /// </summary>
        /// <value>The nodes.</value>
        ICollection<INode> Nodes { get; set; } = new List<INode>();

        /// <summary>
        /// Releases all resource used by the <see cref="T:FlatSquares.Scene"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:FlatSquares.Scene"/>. The
        /// <see cref="Dispose"/> method leaves the <see cref="T:FlatSquares.Scene"/> in an unusable state. After calling
        /// <see cref="Dispose"/>, you must release all references to the <see cref="T:FlatSquares.Scene"/> so the garbage
        /// collector can reclaim the memory that the <see cref="T:FlatSquares.Scene"/> was occupying.</remarks>
        public void Dispose() => Nodes.ForEach(node => node.Dispose());

        /// <summary>
        /// Create the scene with specified parameters.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public abstract void Create(object parameters = null);

        /// <summary>
        /// Create a node.
        /// </summary>
        /// <returns>The created node.</returns>
        /// <param name="key">Node key.</param>
        public INode CreateNode(string key)
        {
            if (Nodes.Any(n => n.Key == key))
                throw new ArgumentException($"Scene {Key} already contains {key}");

            var node = new Node { Key = key };
            Nodes.Add(node);
            return node;
        }

        /// <summary>
        /// Gets a node corresponding to a key.
        /// </summary>
        /// <returns>The node.</returns>
        /// <param name="key">Key.</param>
        public INode GetNode(string key) => Nodes.SingleOrDefault(node => node.Key == key);

        /// <summary>
        /// Remove a node corresponding to a key.
        /// </summary>
        /// <param name="key">Key.</param>
        public void RemoveNode(string key)
        {
            var node = GetNode(key);
            Nodes.Remove(node);
            node.Dispose();
        } 

        /// <summary>
        /// Gets the renderables.
        /// </summary>
        /// <returns>The renderables.</returns>
        public IEnumerable<IInitialize> GetInitializables()
        {
            //TODO will need optimisation
            var initializables = new List<IInitialize>();
            foreach (var node in Nodes)
            {
                initializables.AddRange(node.Components.OfType<IInitialize>().ToList());
            }
            return initializables;
        }

        /// <summary>
        /// Gets the renderables.
        /// </summary>
        /// <returns>The renderables.</returns>
        public IEnumerable<IRender> GetRenderables()
        {
            //TODO will need optimisation
            var renderables = new List<IRender>();
            foreach (var node in Nodes)
            {
                renderables.AddRange(node.Components.OfType<IRender>().ToList());
            }
            return renderables;
        }

        /// <summary>
        /// Gets the loadables.
        /// </summary>
        /// <returns>The loadables.</returns>
        public IEnumerable<ILoad> GetLoadables()
        {
            //TODO will need optimisation
            var loadables = new List<ILoad>();
            foreach (var node in Nodes)
            {
                loadables.AddRange(node.Components.OfType<ILoad>().ToList());
            }
            return loadables;
        }

        /// <summary>
        /// Gets the updatables.
        /// </summary>
        /// <returns>The updatables.</returns>
        public IEnumerable<IUpdate> GetUpdatables()
        {
            //TODO will need optimisation
            var updatables = new List<IUpdate>();
            foreach (var node in Nodes)
            {
                updatables.AddRange(node.Components.OfType<IUpdate>().ToList());
            }
            return updatables;
        }
    }
}
