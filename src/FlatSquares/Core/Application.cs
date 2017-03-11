namespace FlatSquares
{
	/// <summary>
	/// FlatSquares Application.
	/// </summary>
	public sealed class Application<TRoot, TLoading, TSplash> : IApplication<TRoot, TLoading, TSplash>
		where TRoot : IScene
		where TLoading : IScene
		where TSplash : ISplash
	{
		/// <summary>
		/// Gets or sets the navigation.
		/// </summary>
		/// <value>The navigation.</value>
		public INavigation Navigation { get; set; }

		/// <summary>
		/// Gets or sets the scene factory.
		/// </summary>
		/// <value>The scene factory.</value>
		public ISceneFactory SceneFactory { get; set; }

		/// <summary>
		/// Releases all resource used by the <see cref="T:FlatSquares.Application`3"/> object.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:FlatSquares.Application`3"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="T:FlatSquares.Application`3"/> in an unusable state. After
		/// calling <see cref="Dispose"/>, you must release all references to the <see cref="T:FlatSquares.Application`3"/> so
		/// the garbage collector can reclaim the memory that the <see cref="T:FlatSquares.Application`3"/> was occupying.</remarks>
		public void Dispose() => Navigation.Dispose();

		/// <summary>
		/// Perform a draw
		/// </summary>
		public void Draw() => Navigation.GetCurrent().Draw();

		/// <summary>
		/// Start the application.
		/// </summary>
		public void Start()
		{
			SceneFactory.SetLoading<TLoading>();
			SceneFactory.SetRoot<TRoot>();
			SceneFactory.SetSplash<TSplash>();
			Navigation.Start();
		}

		/// <summary>
		/// Perform an update.
		/// </summary>
		/// <param name="elapsed">Elapsed time since last update.</param>
		public void Update(float elapsed) => Navigation.GetCurrent().Update(elapsed);
	}
}
