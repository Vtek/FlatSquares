using FlatSquares.Components;
using FlatSquares.Core;

namespace FruityFalls
{
	public class RootScene : Scene
	{
		/// <summary>
		/// Initialize this instance with the specified paremeter.
		/// </summary>
		/// <param name="paremeter">Paremeter.</param>
		public override void Initialize(object paremeter = null)
		{
			var node = new Node();
			node.AddComponent(new SpinnerComponent());
			node.AddComponent(new SpriteComponent { TexturePath = "Sprites/spinner" });
			Nodes.Add(node);

			base.Initialize(paremeter);
		}
	}
}
