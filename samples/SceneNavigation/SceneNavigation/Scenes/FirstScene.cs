using FlatSquares.Components;
using FlatSquares.Core;
using SceneNavigation.Components;

namespace SceneNavigation.Scenes
{
    public class FirstScene : Scene
    {
        public override void Create(object parameters = null)
        {
            var node = CreateNode("first");
            node.AddComponent(new SpriteComponent { TexturePath = "Sprites/image1" });
            node.AddComponent(new FirstComponent());
        }
    }
}
