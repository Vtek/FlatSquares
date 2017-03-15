using System;

namespace FlatSquares
{
    /// <summary>
    /// Define a Node component
    /// </summary>
    public interface IComponent : IEnabled, IDisposable, IUpdate
    {
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
