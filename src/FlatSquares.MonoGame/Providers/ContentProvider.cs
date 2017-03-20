using System;
using FlatSquares.Providers;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
        public ITexture GetTexture(string resourcePath)
        {
            var texture = ContentManager.Load<Texture2D>(resourcePath);
            return new Texture
            {
                InnerTexture = texture
            };
        }
    }

    class Texture : ITexture
    {
        public int Height => InnerTexture.Height;

        public int Width => InnerTexture.Width;

        public Texture2D InnerTexture { get; set; }

        public static implicit operator Texture2D(Texture t) => t.InnerTexture;
    }
}
