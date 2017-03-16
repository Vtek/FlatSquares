using FlatSquares.Common;
using FlatSquares.Core;

namespace FlatSquares.Components
{
    public class SpriteComponent : Component, IRender, ILoad
    {
        object _internalResource;

        public Vector Origin { get; set; } = Vector.Zero;

        public Vector Position => Node.Position;
        public float Rotation => Node.Rotation;
        public float Scale => Node.Scale;


        public Rectangle Source { get; set; }
        public string TexturePath { get; set; }

        public T GetRenderObject<T>() => (T)_internalResource;

        public void Load() => _internalResource = null; //TODO Providers need to be inject for easier developement of components
    }
}
