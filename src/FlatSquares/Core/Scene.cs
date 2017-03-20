using System;
using System.Collections.Generic;
using System.Linq;
using FlatSquares.Providers;

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
        /// Gets or sets the renderables.
        /// </summary>
        /// <value>The renderables.</value>
        ICollection<IRender> _renderables { get; set; } = new List<IRender>();

        /// <summary>
        /// Gets the renderables.
        /// </summary>
        /// <value>The renderables.</value>
        public IEnumerable<IRender> Renderables => _renderables.Where(r => r.Active).AsEnumerable();

        /// <summary>
        /// Gets or sets the updatables.
        /// </summary>
        /// <value>The updatables.</value>
        ICollection<IUpdate> _updatables { get; set; } = new List<IUpdate>();

        /// <summary>
        /// Gets the updatables.
        /// </summary>
        /// <value>The updatables.</value>
        public IEnumerable<IUpdate> Updatables => _updatables.Where(u => u.Active).AsEnumerable();

        /// <summary>
        /// Gets or sets the dependency provider.
        /// </summary>
        /// <value>The dependency provider.</value>
        public IDependencyProvider DependencyProvider { private get; set; }

        /// <summary>
        /// Releases all resource used by the <see cref="T:FlatSquares.Scene"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:FlatSquares.Scene"/>. The
        /// <see cref="Dispose"/> method leaves the <see cref="T:FlatSquares.Scene"/> in an unusable state. After calling
        /// <see cref="Dispose"/>, you must release all references to the <see cref="T:FlatSquares.Scene"/> so the garbage
        /// collector can reclaim the memory that the <see cref="T:FlatSquares.Scene"/> was occupying.</remarks>
        public void Dispose()
        {
            Nodes.ForEach(node =>
            {
                node.ComponentAdded -= NodeComponentAdded;
                node.ComponentRemoved -= NodeComponentRemoved;
                node.Dispose();
            });
            Nodes.Clear();
        } 

        /// <summary>
        /// Create the scene with specified parameters.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public abstract void Create(object parameters = null);

        /// <summary>
        /// Initialize the scene.
        /// </summary>
        public void Initialize() => Nodes.ForEach(node => node.Initialize());

        /// <summary>
        /// Create a node.
        /// </summary>
        /// <returns>The created node.</returns>
        /// <param name="key">Node key.</param>
        public INode CreateNode(string key)
        {
            if (Nodes.Any(n => n.Key == key))
                throw new ArgumentException($"Scene {Key} already contains {key}");

            var node = new Node { Key = key, Scene = this };
            node.ComponentAdded += NodeComponentAdded;
            node.ComponentRemoved += NodeComponentRemoved;
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
        /// Gets nodes corresponding to a tag.
        /// </summary>
        /// <returns>The nodes.</returns>
        /// <param name="tag">Tag.</param>
        public IEnumerable<INode> GetNodes(string tag) => Nodes.Where(n => n.IsTagged(tag)).AsEnumerable();

        /// <summary>
        /// Remove a node corresponding to a key.
        /// </summary>
        /// <param name="key">Key.</param>
        public void RemoveNode(string key)
        {
            var node = GetNode(key);
            node.ComponentAdded -= NodeComponentAdded;
            node.ComponentRemoved -= NodeComponentRemoved;
            node.Dispose();
            Nodes.Remove(node);
        }

        /// <summary>
        /// Handle  node component added event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="component">Component.</param>
        void NodeComponentAdded(object sender, IComponent component)
        {
            DependencyProvider.Inject(component);

            var render = component as IRender;
            if (render != null)
                _renderables.Add(render);

            var update = component as IUpdate;
            if (update != null)
                _updatables.Add(update);
        }

        /// <summary>
        /// Handle  node component removed event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="component">Component.</param>
        void NodeComponentRemoved(object sender, IComponent component)
        {
            var render = component as IRender;
            if (render != null)
                _renderables.Remove(render);

            var update = component as IUpdate;
            if (update != null)
                _updatables.Remove(update);
        }
    }
}
