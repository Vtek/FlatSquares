using System;
using FlatSquares;
using FlatSquares.Common;
using FlatSquares.Components;
using FlatSquares.Core;
using FlatSquares.Providers;
using SceneNavigation.Scenes;

namespace SceneNavigation.Components
{
    public class FirstComponent : Component, IUpdate, IInitialize
    {
        public IVirtualResolutionProvider VirtualResolutionProvider { get; set; }
        public ITouchProvider TouchProvider { get; set; }
        public INavigation Navigation { get; set; }

        public void Initialize()
        {
            var spriteComponent = Node.GetComponent<SpriteComponent>();
            spriteComponent.Origin = spriteComponent.Source.Center;
            Node.Position = new Vector(VirtualResolutionProvider.Width / 2, VirtualResolutionProvider.Height / 2);
        }

        public void Update(float elapsed)
        {
            if (TouchProvider.Up(0))
                Navigation.Push<SecondScene>();
        }
    }
}
