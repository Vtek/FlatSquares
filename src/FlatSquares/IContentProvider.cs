namespace FlatSquares
{
    /// <summary>
    /// Content provider.
    /// </summary>
    public interface IContentProvider
    {
        /// <summary>
        /// Load a resource.
        /// </summary>
        /// <returns>Resource.</returns>
        /// <param name="resourcePath">Resource path.</param>
        object Load(string resourcePath);
    }
}
