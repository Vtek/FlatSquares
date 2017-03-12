using FlatSquares.Common;
using FlatSquares.Core;

namespace FlatSquares.Components
{
	public class SpriteComponent : Component, IRender, ILoad
	{
		object _internalResource;

		public Vector Origin { get; } = Vector.Zero; //TODO

		public Vector Position => Node.Position;
		public float Rotation => Node.Rotation;
		public float Scale => Node.Scale;


		public Rectangle Source { get; set; }
		public string TexturePath { get; set; }

		public T GetRenderObject<T>() => (T)_internalResource;

		public void Load(IContentProvider contentProvider) => _internalResource = contentProvider.Load(TexturePath);
	}
}
