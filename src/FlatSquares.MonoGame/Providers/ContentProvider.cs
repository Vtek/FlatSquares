using FlatSquares.Providers;
using Microsoft.Xna.Framework.Content;

namespace FlatSquares.MonoGame.Providers
{
    /// <summary>
    /// Content provider.
    /// </summary>
    class ContentProvider : IContentProvider
    {
        /// <summary>
        /// Gets or sets the content manager.
        /// </summary>
        /// <value>The content manager.</value>
        public ContentManager ContentManager { get; set; }

        /// <summary>
        /// Load a resource.
        /// </summary>
        /// <returns>Resource.</returns>
        /// <param name="resourcePath">Resource path.</param>
        public object Load(string resourcePath) => ContentManager.Load<object>(resourcePath);
    }
}
