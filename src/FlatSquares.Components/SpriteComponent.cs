using FlatSquares.Common;
using FlatSquares.Core;
using FlatSquares.Providers;

namespace FlatSquares.Components
{
    public class SpriteComponent : Component, IRender, ILoad
    {
        public IContentProvider ContentProvider { get; set; }

        public Vector Origin { get; set; } = Vector.Zero;
        public Vector Position => Node.Position;
        public float Rotation => Node.Rotation;
        public float Scale => Node.Scale;
        public Rectangle Source { get; set; }
        public string TexturePath { get; set; }
        public object Texture { get; private set; }

        public void Load() => Texture = ContentProvider.Load(TexturePath);
    }
}
