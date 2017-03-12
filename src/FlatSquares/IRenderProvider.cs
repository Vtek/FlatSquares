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
		/// Draw the specified render.
		/// </summary>
		/// <returns>The draw.</returns>
		/// <param name="render">Render.</param>
		void Draw(IRender render);

		/// <summary>
		/// End render process.
		/// </summary>
		void End();
	}
}
