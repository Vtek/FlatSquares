using FlatSquares.Common;
using FlatSquares.Components;
using FlatSquares.Core;

namespace Sprite
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
            var background = CreateNode("backgound");
            background.Position = new Vector(0, 0);
            background.AddComponent(new SpriteComponent{ TexturePath = "Sprites/background" });

            var node = CreateNode("star");
            node.Scale = 0.5f;
            node.AddComponent(new SpriteComponent { TexturePath = "Sprites/star" });
            node.AddComponent(new SpinnerComponent { Speed = 1f });
        }
    }
}
