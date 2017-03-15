using FlatSquares.Common;

namespace FlatSquares
{
    /// <summary>
    /// Define an object to render.
    /// </summary>
    public interface IRender
    {
        /// <summary>
        /// Gets the render object.
        /// </summary>
        /// <returns>The render object.</returns>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        T GetRenderObject<T>();

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
