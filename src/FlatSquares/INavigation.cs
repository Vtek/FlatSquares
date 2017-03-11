using System.Threading.Tasks;

namespace FlatSquares
{
	/// <summary>
	/// Define game navigation
	/// </summary>
	public interface INavigation
	{
		/// <summary>
		/// Push a Scene into the navigation stack.
		/// </summary>
		/// <param name="parameter">Optinal parameter</param>
		Task Push<TScene>(object parameter = null) where TScene: IScene;

		/// <summary>
		/// Remove the top Scene in the navigation stack.
		/// </summary>
		/// <returns>The pop.</returns>
		Task Pop();

		/// <summary>
		/// Pops all but the root scene off the navigation stack.
		/// </summary>
		/// <returns>The to root.</returns>
		Task PopToRoot();
	}
}
