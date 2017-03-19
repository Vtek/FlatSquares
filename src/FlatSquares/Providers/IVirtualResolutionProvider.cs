namespace FlatSquares.Providers
{
    /// <summary>
    /// Define a virtual resolution provider.
    /// </summary>
    public interface IVirtualResolutionProvider
    {
        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        float Width { get; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        float Height { get; }
    }
}