namespace FlatSquares
{
	/// <summary>
	/// Define a node factory.
	/// </summary>
	public interface INodeFactory
	{
		/// <summary>
		/// Creates a node.
		/// </summary>
		/// <returns>Node instance.</returns>
		INode CreateNode();
	}
}
