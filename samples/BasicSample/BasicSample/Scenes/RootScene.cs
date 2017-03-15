using FlatSquares.Common;
using FlatSquares.Components;
using FlatSquares.Core;

namespace BasicSample
{
    /// <summary>
    /// Root scene.
    /// </summary>
    public class RootScene : Scene
    {
        /// <summary>
        /// Create the scene with specified parameters.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public override void Create(object parameters = null)
        {
            for (var i = 0; i < 1; i++)
            {
                for (var y = 0; y < 1; y++)
                {
                    var node = CreateNode($"Node{i}");
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
                }
            }

        }
    }
}
