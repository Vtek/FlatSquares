using FlatSquares.Common;
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
            for (var i = 0; i < 50; i++)
            {
                for (var y = 0; y< 50; y++)
                {
                    var node = new Node();
                    node.Position = new Vector(i * 50, y * 50);
                    node.AddComponent(new SpinnerComponent
                    {
                        Speed = i * y * 0.1f + 0.1f
                    });
                    node.AddComponent(new SpriteComponent
                    {
                        Source = new Rectangle(0f, 0f, 50f, 50f),
                        TexturePath = "Sprites/spinner",
                        Origin = new Vector(25f, 25f)
                    });
                    Nodes.Add(node);
                }
            }
			
		}
	}
}
