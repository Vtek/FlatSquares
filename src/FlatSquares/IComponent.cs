using System;

namespace FlatSquares
{
	/// <summary>
	/// Define a Node component
	/// </summary>
	public interface IComponent : IEnabled, IDisposable, IUpdate
	{
		
	}
}
