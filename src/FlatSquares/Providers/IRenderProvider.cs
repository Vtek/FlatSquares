using FlatSquares.Common;

namespace FlatSquares.Providers
{
    /// <summary>
    /// Render provider.
    /// </summary>
    public interface IRenderProvider
    {
        /// <summary>
        /// Gets or sets the clear color.
        /// </summary>
        /// <value>The clear color.</value>
        Color Clear { get; set; }

        /// <summary>
        /// Begin render operation.
        /// </summary>
        void Begin();

        /// <summary>
        /// Draw operation.
        /// </summary>
        /// <returns>The draw.</returns>
        /// <param name="render">Render.</param>
        void Draw(IRender render);

        /// <summary>
        /// End render operation.
        /// </summary>
        void End();
    }
}
