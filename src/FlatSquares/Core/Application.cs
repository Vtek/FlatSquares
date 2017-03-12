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

		Color Clear { get; set; }

		/// <summary>
		/// Occurs when started.
		/// </summary>
		public event EventHandler Started;

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
		public void Draw() 
		{
			RenderProvider.Begin(Clear);
			Navigation.GetCurrent().GetRenderables().ForEach(RenderProvider.Draw);
			RenderProvider.End();
		}

		/// <summary>
		/// Sets the color for the clear operation.
		/// </summary>
		/// <returns>The clear color.</returns>
		/// <param name="color">Color.</param>
		public IApplication SetClearColor(Color color)
		{
			Clear = color;
			return this;
		}

		/// <summary>
		/// Sets the virtual resolution.
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		public IApplication SetVirtualResolution(int width, int height)
		{
			RenderProvider.WidthRequired = width;
			RenderProvider.HeightRequired = height;
			return this;
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
		/// Perform an update.
		/// </summary>
		/// <param name="elapsed">Elapsed time since last update.</param>
		public void Update(float elapsed) => Navigation.GetCurrent().Update(elapsed);

		/// <summary>
		/// Sets the content root path.
		/// </summary>
		/// <returns>The content root path.</returns>
		/// <param name="path">Path.</param>
		public IApplication SetContentRootPath(string path)
		{
			ContentProvider.RootPath = path;
			return this;
		}

        public void Initialize(object paremeter = null)
        {
            Navigation.Start();
        }
    }
}
