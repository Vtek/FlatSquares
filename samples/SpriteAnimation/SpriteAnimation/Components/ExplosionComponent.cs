using System;
using FlatSquares;
using FlatSquares.Core;
using FlatSquares.Providers;
using FlatSquares.Components;
using FlatSquares.Common;

namespace SpriteAnimation.Components
{
    public class ExplosionComponent : Component, IUpdate, IInitialize
    {
        public ITouchProvider TouchProvider { get; set; }

        AnimatedSpriteComponent AnimatedSpriteComponent { get; set; }

        public void Initialize()
        {
            AnimatedSpriteComponent = Node.GetComponent<AnimatedSpriteComponent>();
            AnimatedSpriteComponent.SetCurrent("explosion");
            AnimatedSpriteComponent.Origin = new Vector(32, 32);
        }

        public void Update(float elapsed)
        {
            if(TouchProvider.Up(0)) 
            {
                Node.Position = TouchProvider.GetPosition(0).Value;
                AnimatedSpriteComponent.Play();
            }
        }
    }
}
