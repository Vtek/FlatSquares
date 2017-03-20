using FlatSquares.Common;

namespace FlatSquares
{
    /// <summary>
    /// Define an object to render.
    /// </summary>
    public interface IRender : IActive
    {
        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <value>The texture.</value>
        ITexture Texture { get; }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>The position.</value>
        Vector Position { get; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>The source.</value>
        Rectangle Source { get; }

        /// <summary>
        /// Gets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        float Rotation { get; }

        /// <summary>
        /// Gets the origin.
        /// </summary>
        /// <value>The origin.</value>
        Vector Origin { get; }

        /// <summary>
        /// Gets the scale.
        /// </summary>
        /// <value>The scale.</value>
        float Scale { get; }
    }
}
