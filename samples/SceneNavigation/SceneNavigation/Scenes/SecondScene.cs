using FlatSquares.Components;
using FlatSquares.Core;
using SceneNavigation.Components;

namespace SceneNavigation.Scenes
{
    public class SecondScene : Scene
    {
        public override void Create(object parameters = null)
        {
            var node = CreateNode("second");
            node.AddComponent(new SpriteComponent { TexturePath = "Sprites/image2" });
            node.AddComponent(new SecondComponent());
        }
    }
}
