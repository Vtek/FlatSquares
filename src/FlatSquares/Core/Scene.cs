using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FlatSquares.Core
{
    /// <summary>
    /// Scene.
    /// </summary>
    public class Scene : IScene
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
        public IList<INode> Nodes { get; set; } = new List<INode>();

        /// <summary>
        /// Releases all resource used by the <see cref="T:FlatSquares.Scene"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:FlatSquares.Scene"/>. The
        /// <see cref="Dispose"/> method leaves the <see cref="T:FlatSquares.Scene"/> in an unusable state. After calling
        /// <see cref="Dispose"/>, you must release all references to the <see cref="T:FlatSquares.Scene"/> so the garbage
        /// collector can reclaim the memory that the <see cref="T:FlatSquares.Scene"/> was occupying.</remarks>
        public void Dispose() => Nodes.ForEach(node => node.Dispose());

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
        /// Initialize this instance with the specified paremeter.
        /// </summary>
        /// <param name="paremeter">Paremeter.</param>
        public virtual void Initialize(object paremeter = null)
        {
        }

        /// <summary>
        /// Perform an update.
        /// </summary>
        /// <param name="elapsed">Elapsed time since last update.</param>
        public void Update(float elapsed) => Nodes.ForEach(node => node.Components.ForEach(component => component.Update(elapsed)));
    }
}
