using System;

namespace FlatSquares
{
    /// <summary>
    /// Define a Node component
    /// </summary>
    public interface IComponent : IEnabled, IDisposable
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="T:FlatSquares.IComponent"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        bool Active { get; }

        /// <summary>
        /// Gets or sets the node.
        /// </summary>
        /// <value>The node.</value>
        INode Node { get; }

        /// <summary>
        /// Sets the node.
        /// </summary>
        /// <param name="node">Node.</param>
        void SetNode(INode node);
    }
}
