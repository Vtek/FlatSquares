using FlatSquares.Core;

namespace FruityFalls
{
	public class SpinnerComponent : Component
	{
		float Speed { get; } = 75f;

		public override void Update(float elapsed)
		{
			Node.Rotation = Node.Rotation * elapsed * 75f;
			base.Update(elapsed);
		}
	}
}
