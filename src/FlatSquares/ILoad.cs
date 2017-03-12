namespace FlatSquares
{
	/// <summary>
	/// Load.
	/// </summary>
	public interface ILoad
	{
		/// <summary>
		/// Loads contents.
		/// </summary>
		/// <param name="contentProvider">Content provider.</param>
		void Load(IContentProvider contentProvider);
	}
}
