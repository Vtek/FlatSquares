using Autofac;
using FlatSquares.MonoGame.Dependencies.Modules;
using FlatSquares.MonoGame.Providers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatSquares
{
    /// <summary>
    /// Application extension.
    /// </summary>
    public static class ApplicationExtension
    {
        static InternalGame internalGame;

        /// <summary>
        /// Use MonoGame providers.
        /// </summary>
        public static IApplication UseMonoGame(this IApplication application)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<InfrastructureModule>();
            containerBuilder.RegisterModule<ProviderModule>();
            containerBuilder.RegisterModule<CoreModule>();
            var container = containerBuilder.Build();

            internalGame = container.Resolve<InternalGame>();
            container.InjectProperties(application);
            container.InjectProperties(internalGame);

            return application;
        }
    }

    /// <summary>
    /// Internal game.
    /// </summary>
    class InternalGame : Game
    {
        IApplication _application;

        /// <summary>
        /// Gets or sets the application.
        /// </summary>
        /// <value>The application.</value>
        public IApplication Application
        {
            get
            {
                return _application;
            }
            set
            {
                _application = value;
                _application.Started += (sender, e) => Run();
            }
        }

        /// <summary>
        /// Gets or sets the render provider.
        /// </summary>
        /// <value>The render provider.</value>
        public IRenderProvider RenderProvider { get; set; }

        /// <summary>
        /// Gets or sets the content provider.
        /// </summary>
        /// <value>The content provider.</value>
        public IContentProvider ContentProvider { get; set; }

        /// <summary>
        /// Gets or sets the graphics device manager.
        /// </summary>
        /// <value>The graphics device manager.</value>
        GraphicsDeviceManager GraphicsDeviceManager { get; set; }

        /// <summary>
        /// Initialize the game
        /// </summary>
        protected override void Initialize()
        {
            ((ContentProvider)ContentProvider).ContentManager = Content;
            ((RenderProvider)RenderProvider).GraphicsDeviceManager = GraphicsDeviceManager;

            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            GraphicsDeviceManager.SynchronizeWithVerticalRetrace = false;
            IsFixedTimeStep = false;

            Application.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// Load game contents.
        /// </summary>
        protected override void LoadContent()
        {
            ((RenderProvider)RenderProvider).SpriteBatch = new SpriteBatch(GraphicsDeviceManager.GraphicsDevice);
            base.LoadContent();
        }

        /// <summary>
        /// Update the game.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        protected override void Update(GameTime gameTime)
        {
            Application.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw the game.
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        protected override void Draw(GameTime gameTime)
        {
            Application.Draw();
            base.Draw(gameTime);
        }
    }
}