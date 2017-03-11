namespace System.Collections.Generic
{
	/// <summary>
	/// Enumerable extensions.
	/// </summary>
	public static class EnumerableExtension
	{
		/// <summary>
		/// Apply an action on each item of an enumerable.
		/// </summary>
		/// <param name="enumerable">Enumerable.</param>
		/// <param name="action">Action.</param>
		public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			foreach (var item in enumerable)
				action(item);
		}
	}
}