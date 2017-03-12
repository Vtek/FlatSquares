using FlatSquares.Common;

namespace FlatSquares
{
	/// <summary>
	/// Render provider.
	/// </summary>
	public interface IRenderProvider
	{
		/// <summary>
		/// Gets or sets the width required.
		/// </summary>
		/// <value>The width required.</value>
		int WidthRequired { get; set; }

		/// <summary>
		/// Gets or sets the height required.
		/// </summary>
		/// <value>The height required.</value>
		int HeightRequired { get; set; }

		/// <summary>
		/// Begin render process.
		/// </summary>
		/// <param name="color">Clear color.</param>
		void Begin(Color color);

		/// <summary>
		/// Draw a render object.
		/// </summary>
		/// <param name="render">Render.</param>
		/// <param name="destination">Destination.</param>
		/// <param name="source">Source.</param>
		/// <param name="rotation">Rotation.</param>
		/// <param name="origin">Origin.</param>
		void Draw(IRender render, Rectangle destination, Rectangle source, float rotation, Vector origin);

		/// <summary>
		/// Draw a render object.
		/// </summary>
		/// <returns>The draw.</returns>
		/// <param name="render">Render.</param>
		/// <param name="position">Position.</param>
		/// <param name="source">Source.</param>
		/// <param name="rotation">Rotation.</param>
		/// <param name="origin">Origin.</param>
		/// <param name="scale">Scale.</param>
		void Draw(IRender render, Vector position, Rectangle source, float rotation, Vector origin, float scale);

		/// <summary>
		/// End render process.
		/// </summary>
		void End();
	}
}
