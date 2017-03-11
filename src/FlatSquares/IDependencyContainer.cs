using System;

namespace FlatSquares
{
	/// <summary>
	/// Define a dependency container
	/// </summary>
	public interface IDependencyContainer : IDisposable
	{
		/// <summary>
		/// Gets an instances.
		/// </summary>
		/// <returns>Instance corresponding to a T type.</returns>
		TType GetInstance<TType>();
	}
}
