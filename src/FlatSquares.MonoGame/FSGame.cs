using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatSquares.MonoGame
{
	public class FSGame : Game
	{
		IApplication Application { get; set; }
		IRenderProvider RenderProvider { get; set; }
        GraphicsDeviceManager GraphicsDeviceManager { get; set; }

		public FSGame(IApplication application, IContentProvider contentProvider, IRenderProvider renderProvider)
		{
			Application = application;
			RenderProvider = renderProvider;

            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            GraphicsDeviceManager.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;

			((ContentProvider)contentProvider).ContentManager = Content;
			((RenderProvider)RenderProvider).GraphicsDeviceManager = GraphicsDeviceManager;

			Application.Started += Application_Started;
		}

		void Application_Started(object sender, EventArgs e)
		{
			Run();
		}

		protected override void LoadContent()
		{
            ((RenderProvider)RenderProvider).SpriteBatch = new SpriteBatch(GraphicsDeviceManager.GraphicsDevice);
			base.LoadContent();
		}

		protected override void Initialize()
		{
			base.Initialize();
            Application.Initialize();
		}

		protected override void Update(GameTime gameTime)
		{
            Application.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{	
			Application.Draw();
            base.Draw(gameTime);
		}
	}
}
