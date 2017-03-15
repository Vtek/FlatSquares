namespace FlatSquares.Core
{
    /// <summary>
    /// Component.
    /// </summary>
    public class Component : IComponent
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:FlatSquares.Core.Component"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <value>The node.</value>
        public INode Node { get; private set; }

        /// <summary>
        /// Releases all resource used by the <see cref="T:FlatSquares.Core.Component"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:FlatSquares.Core.Component"/>. The
        /// <see cref="Dispose"/> method leaves the <see cref="T:FlatSquares.Core.Component"/> in an unusable state. After
        /// calling <see cref="Dispose"/>, you must release all references to the <see cref="T:FlatSquares.Core.Component"/>
        /// so the garbage collector can reclaim the memory that the <see cref="T:FlatSquares.Core.Component"/> was occupying.</remarks>
        public virtual void Dispose() => Node = null;

        /// <summary>
        /// Sets the node.
        /// </summary>
        /// <param name="node">Node.</param>
        public void SetNode(INode node) => Node = node;
    }
}
