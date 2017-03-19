using System;
using FlatSquares.Providers;

namespace FlatSquares.MonoGame.Providers
{
    /// <summary>
    /// Virtual resolution provider.
    /// </summary>
    public class VirtualResolutionProvider : IVirtualResolutionProvider
    {
        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public float Height { get; internal set; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public float Width { get; internal set; }
    }
}
