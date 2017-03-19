﻿using FlatSquares.Common;
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
            background.AddComponent(new SpriteComponent
            {
                Source = new Rectangle(0f, 0f, 854f, 480f),
                TexturePath = "Sprites/background"
            });

            for (var i = 0; i < 1; i++)
            {
                for (var y = 0; y < 1; y++)
                {
                    var node = CreateNode($"Node{i}");
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
