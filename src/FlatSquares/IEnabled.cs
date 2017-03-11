namespace FlatSquares
{
	/// <summary>
	/// Define enabled behavior
	/// </summary>
	public interface IEnabled
	{
		/// <summary>
		/// Gets or sets a value indicating whether this instance is enabled.
		/// </summary>
		/// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
		bool Enabled { get; set; }
	}
}
