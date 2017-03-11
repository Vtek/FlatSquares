namespace FlatSquares
{
	/// <summary>
	/// Scene factory.
	/// </summary>
	public interface ISceneFactory
	{
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
		/// Create a scene.
		/// </summary>
		/// <returns>The create.</returns>
		/// <typeparam name="TScene">Scene type to create.</typeparam>
		TScene Create<TScene>() where TScene : IScene;
	}
}
