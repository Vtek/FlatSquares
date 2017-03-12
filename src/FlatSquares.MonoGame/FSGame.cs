using System;
using Microsoft.Xna.Framework;

namespace FlatSquares.MonoGame
{
	public class FSGame : Game
	{
		IApplication Application { get; set; }
		IRenderProvider RenderProvider { get; set; }

		public FSGame(IApplication application, IContentProvider contentProvider, IRenderProvider renderProvider)
		{
			Application = application;
			RenderProvider = renderProvider;

			((ContentProvider)contentProvider).ContentManager = Content;
			((RenderProvider)RenderProvider).GraphicsDeviceManager = new GraphicsDeviceManager(this);

			Application.Started += Application_Started;
		}

		void Application_Started(object sender, EventArgs e)
		{
			Run();
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void Update(GameTime gameTime)
		{
			Application.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{	
			Application.Draw();
			base.Draw(gameTime);
		}
	}
}
