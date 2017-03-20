namespace FlatSquares.Providers
{
    /// <summary>
    /// Content provider.
    /// </summary>
    public interface IContentProvider
    {
        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <returns>The texture.</returns>
        /// <param name="resourcePath">Resource path.</param>
        ITexture GetTexture(string resourcePath);
    }
}
