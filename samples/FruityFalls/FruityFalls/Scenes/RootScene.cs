using FlatSquares;
using FlatSquares.Components;
using FlatSquares.Core;

namespace FruityFalls
{
	public class RootScene : Scene
	{
		/// <summary>
		/// Gets or sets the node factory.
		/// </summary>
		/// <value>The node factory.</value>
		INodeFactory NodeFactory { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FruityFalls.LoadingScene"/> class.
		/// </summary>
		/// <param name="nodeFactory">Node factory.</param>
		public RootScene(INodeFactory nodeFactory)
		{
			NodeFactory = nodeFactory;
		}

		/// <summary>
		/// Initialize this instance with the specified paremeter.
		/// </summary>
		/// <param name="paremeter">Paremeter.</param>
		public override void Initialize(object paremeter = null)
		{
			var node = NodeFactory.CreateNode();
			node.AddComponent(new SpinnerComponent());
			node.AddComponent(new SpriteComponent { TexturePath = "Sprites/spinner.png" });
			Nodes.Add(node);

			base.Initialize(paremeter);
		}
	}
}
