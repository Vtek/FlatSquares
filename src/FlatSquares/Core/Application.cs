using System;
using System.Collections.Generic;
using FlatSquares.Common;

namespace FlatSquares.Core
{
	/// <summary>
	/// FlatSquares Application.
	/// </summary>
	public sealed class Application : IApplication
	{
        /// <summary>
        /// Occurs when started.
        /// </summary>
        public event EventHandler Started;

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
		/// Gets or sets the content provider.
		/// </summary>
		/// <value>The content provider.</value>
		public IContentProvider ContentProvider { get; set; }

		/// <summary>
		/// Gets or sets the render provider.
		/// </summary>
		/// <value>The render provider.</value>
		public IRenderProvider RenderProvider { get; set; }

        /// <summary>
        /// Gets or sets the color of the clear.
        /// </summary>
        /// <value>The color of the clear.</value>
        Color ClearColor { get; set; }

		/// <summary>
		/// Define basic game scene.
		/// </summary>
		public IApplication Define<TSplash, TLoading>()
			where TSplash : ISplash
			where TLoading : IScene
		{
			SceneFactory.SetSplash<TSplash>();
			SceneFactory.SetLoading<TLoading>();
			return this;
		}

        /// <summary>
        /// Apply the specified configuration.
        /// </summary>
        /// <returns>The apply.</returns>
        /// <param name="configuration">Configuration.</param>
        public void Apply(Configuration configuration)
        {
            ClearColor = configuration.ClearColor;
        }

        /// <summary>
		/// Start the application.
		/// </summary>
		public void Start<TRoot>() where TRoot: IScene
		{
			SceneFactory.SetRoot<TRoot>();
			Started?.Invoke(this, EventArgs.Empty);
		}

        /// <summary>
        /// Initialize the application.
        /// </summary>
        /// <returns>The initialize.</returns>
        /// <param name="paremeter">Paremeter.</param>
        public void Initialize(object paremeter = null)
        {
            Navigation.Start();
        }

		/// <summary>
		/// Perform an update.
		/// </summary>
		/// <param name="elapsed">Elapsed time since last update.</param>
		public void Update(float elapsed) => Navigation.GetCurrent().Update(elapsed);

        /// <summary>
        /// Perform a draw
        /// </summary>
        public void Draw()
        {
            RenderProvider.Begin(ClearColor);
            Navigation.GetCurrent().GetRenderables().ForEach(RenderProvider.Draw);
            RenderProvider.End();
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:FlatSquares.Application`3"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:FlatSquares.Application`3"/>. The
        /// <see cref="Dispose"/> method leaves the <see cref="T:FlatSquares.Application`3"/> in an unusable state. After
        /// calling <see cref="Dispose"/>, you must release all references to the <see cref="T:FlatSquares.Application`3"/> so
        /// the garbage collector can reclaim the memory that the <see cref="T:FlatSquares.Application`3"/> was occupying.</remarks>
        public void Dispose() => Navigation.Dispose();
    }
}
