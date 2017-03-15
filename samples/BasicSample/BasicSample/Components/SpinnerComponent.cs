using FlatSquares;
using FlatSquares.Common;
using FlatSquares.Core;

namespace BasicSample
{
    public class SpinnerComponent : Component, IUpdate
    {
        public float Speed { get; set; }

        public void Update(float elapsed)
        {
            Node.Rotation += elapsed;
            Node.Rotation = Node.Rotation % (MathHelper.Pi * 2);
        }
    }
}
