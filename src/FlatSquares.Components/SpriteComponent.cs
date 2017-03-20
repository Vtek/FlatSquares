using FlatSquares.Common;
using FlatSquares.Core;
using FlatSquares.Providers;

namespace FlatSquares.Components
{
    /// <summary>
    /// Sprite component.
    /// </summary>
    public class SpriteComponent : Component, IRender, ILoad, IInitialize
    {
        /// <summary>
        /// Gets or sets the content provider.
        /// </summary>
        /// <value>The content provider.</value>
        public IContentProvider ContentProvider { get; set; }

        /// <summary>
        /// Gets or sets the origin.
        /// </summary>
        /// <value>The origin.</value>
        public Vector Origin { get; set; } = Vector.Zero;

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>The position.</value>
        public Vector Position => Node.Position;

        /// <summary>
        /// Gets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        public float Rotation => Node.Rotation;

        /// <summary>
        /// Gets the scale.
        /// </summary>
        /// <value>The scale.</value>
        public float Scale => Node.Scale;

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public Rectangle Source { get; set; }

        /// <summary>
        /// Gets or sets the texture path.
        /// </summary>
        /// <value>The texture path.</value>
        public string TexturePath { get; set; }

        /// <summary>
        /// Gets the texture.
        /// </summary>
        /// <value>The texture.</value>
        public ITexture Texture { get; private set; }

        /// <summary>
        /// Load this instance.
        /// </summary>
        public void Load() => Texture = ContentProvider.GetTexture(TexturePath);

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public void Initialize()
        {
            if (Source.IsEmpty)
                Source = new Rectangle(0, 0, Texture.Width, Texture.Height);
        }
    }
}
