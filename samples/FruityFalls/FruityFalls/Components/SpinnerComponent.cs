using FlatSquares.Core;

namespace FruityFalls
{
	public class SpinnerComponent : Component
	{
        public float Speed { get; set; }

		public override void Update(float elapsed)
		{
            Node.Rotation += elapsed * Speed;
		}
	}
}
