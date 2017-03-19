using FlatSquares;
using FlatSquares.Common;
using FlatSquares.Core;
using FlatSquares.Providers;

namespace Sprite
{
    public class SpinnerComponent : Component, IUpdate
    {
        public ITouchProvider TouchProvider { get; set; }

        public float Speed { get; set; }

        public void Update(float elapsed)
        {
            if(TouchProvider.Up(0))
                Node.Position = TouchProvider.GetPosition(0).Value;

            Node.Rotation += elapsed;
            Node.Rotation = Node.Rotation % (MathHelper.Pi * 2);
        }
    }
}
