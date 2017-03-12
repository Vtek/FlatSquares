namespace FlatSquares
{
	/// <summary>
	/// Content provider.
	/// </summary>
	public interface IContentProvider
	{
		/// <summary>
		/// Gets or sets the root path.
		/// </summary>
		/// <value>The root path.</value>
		string RootPath { get; set; }

		/// <summary>
		/// Load a resource.
		/// </summary>
		/// <returns>Resource.</returns>
		/// <param name="resourcePath">Resource path.</param>
		object Load(string resourcePath);
	}
}
