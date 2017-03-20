using System;
using FlatSquares;
using FlatSquares.Core;
using FlatSquares.Providers;
using FlatSquares.Components;

namespace SpriteAnimation.Components
{
    public class UserInputComponent : Component, IUpdate, IInitialize
    {
        public ITouchProvider TouchProvider { get; set; }
        AnimatedSpriteComponent AnimatedSpriteComponent { get; set; }

        public void Initialize()
        {
            AnimatedSpriteComponent = Node.GetComponent<AnimatedSpriteComponent>();
        }

        public void Update(float elapsed)
        {
            if(TouchProvider.Up(0)){
                AnimatedSpriteComponent.Reset();
            }
        }
    }
}
