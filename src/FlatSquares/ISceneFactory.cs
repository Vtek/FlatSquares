using System.Collections.Generic;

namespace FlatSquares
{
	/// <summary>
	/// Scene factory.
	/// </summary>
	public interface ISceneFactory
	{
		/// <summary>
		/// Gets the root.
		/// </summary>
		/// <value>The root.</value>
		IScene Root { get; }

		/// <summary>
		/// Gets the loading.
		/// </summary>
		/// <value>The loading.</value>
		IScene Loading { get; }

		/// <summary>
		/// Gets the splash.
		/// </summary>
		/// <value>The splash.</value>
		ISplash Splash { get; }

		/// <summary>
		/// Sets the root scene.
		/// </summary>
		/// <typeparam name="TScene">Root scene type.</typeparam>
		void SetRoot<TScene>() where TScene : IScene;

		/// <summary>
		/// Sets the loading scene. 
		/// </summary>
		/// <typeparam name="TScene">Loading scene type.</typeparam>
		void SetLoading<TScene>() where TScene : IScene;

		/// <summary>
		/// Sets the splash scene.
		/// </summary>
		/// <typeparam name="TScene">Splash scene type.</typeparam>
		void SetSplash<TScene>() where TScene : ISplash;

		/// <summary>
		/// Create a scene.
		/// </summary>
		/// <returns>Scene.</returns>
		/// <typeparam name="TScene">Scene type to create.</typeparam>
		TScene Create<TScene>() where TScene : IScene;
	}
}
