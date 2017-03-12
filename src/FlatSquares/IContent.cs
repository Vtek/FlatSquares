namespace FlatSquares
{
	/// <summary>
	/// Define an object which need to load external contents.
	/// </summary>
	public interface IContent
	{
		/// <summary>
		/// Loads contents.
		/// </summary>
		/// <param name="contentProvider">Content provider.</param>
		void LoadContent(IContentProvider contentProvider);
	}
}
