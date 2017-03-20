using FlatSquares;
using FlatSquares.Common;
using FlatSquares.Components;
using FlatSquares.Core;
using FlatSquares.Providers;

namespace Sprite
{
    public class SpinnerComponent : Component, IUpdate, IInitialize
    {
        //public ITouchProvider TouchProvider { get; set; }
        public IVirtualResolutionProvider VirtualResolutionProvider { get; set; }

        public float Speed { get; set; }

        public void Initialize()
        {
            var spriteComponent = Node.GetComponent<SpriteComponent>();
            spriteComponent.Origin = spriteComponent.Source.Center;
            Node.Position = new Vector(VirtualResolutionProvider.Width / 2, VirtualResolutionProvider.Height / 2);
        }

        public void Update(float elapsed)
        {
            /*if(TouchProvider.Up(0))
                Node.Position = TouchProvider.GetPosition(0).Value;*/

            Node.Rotation += elapsed;
            Node.Rotation = Node.Rotation % (MathHelper.Pi * 2);
        }


    }
}
