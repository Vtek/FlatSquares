using System;
using FlatSquares.Common;
using FlatSquares.Components;
using FlatSquares.Core;
using SpriteAnimation.Components;

namespace SpriteAnimation.Scenes
{
    public class RootScene : Scene
    {
        public override void Create(object parameters = null)
        {
            var node = CreateNode("explosion");

            var animation = new AnimatedSpriteComponent
            {
                TexturePath = "Sprites/explosion",
                Duration = 0.5f
            };
            animation.AddAnimation("explosion", new[]
            {
                new Rectangle(0, 0,   64, 64), new Rectangle(64, 0,   64, 64), new Rectangle(128, 0,   64, 64), new Rectangle(192, 0,   64, 64), new Rectangle(256, 0,   64, 64),
                new Rectangle(0, 64,  64, 64), new Rectangle(64, 64 , 64, 64), new Rectangle(128, 64,  64, 64), new Rectangle(192, 64,  64, 64), new Rectangle(256, 64,  64, 64),
                new Rectangle(0, 128, 64, 64), new Rectangle(64, 128, 64, 64), new Rectangle(128, 128, 64, 64), new Rectangle(192, 128, 64, 64), new Rectangle(256, 128, 64, 64),
                new Rectangle(0, 192, 64, 64), new Rectangle(64, 192, 64, 64), new Rectangle(128, 192, 64, 64), new Rectangle(192, 192, 64, 64), new Rectangle(256, 192, 64, 64),
                new Rectangle(0, 256, 64, 64), new Rectangle(64, 256, 64, 64), new Rectangle(128, 256, 64, 64), new Rectangle(192, 256, 64, 64), new Rectangle(256, 256, 64, 64)
            });
            animation.SetCurrent("explosion");

            node.AddComponent(animation);
            node.AddComponent(new UserInputComponent());

            
        }
    }
}
