namespace FlatSquares
{
	/// <summary>
	/// Define an object to render.
	/// </summary>
	public interface IRender
	{
		/// <summary>
		/// Gets the render object.
		/// </summary>
		/// <returns>The render object.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		T GetRenderObject<T>();
	}
}
