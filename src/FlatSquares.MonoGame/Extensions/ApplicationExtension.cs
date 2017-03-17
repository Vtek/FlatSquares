using System;
using System.Linq;
using System.Reflection;
using Autofac;
using FlatSquares.Common;
using FlatSquares.MonoGame.Dependencies.Modules;
using FlatSquares.MonoGame.Providers;
using FlatSquares.Providers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatSquares.Core
{
    /// <summary>
    /// Application extension.
    /// </summary>
    public static class ApplicationExtension
    {
        /// <summary>
        /// Register a scene.
        /// </summary>
        public static IApplication RegisterScene<TScene>(this IApplication application) where TScene : IScene
        {
            CoreModule.Scenes.Add(typeof(TScene));
            return application;
        }

        /// <summary>
        /// Registers scenes from an Assembly.
        /// </summary>
        /// <param name="assembly">Assembly.</param>
        public static IApplication RegisterScenes(this IApplication application, Assembly assembly)
        {
            var sceneTypes = assembly.DefinedTypes
                                     .Where(type => type.ImplementedInterfaces.Any(i => i.Name == typeof(IScene).Name))
                                     .Select(type => type.AsType())
                                     .ToArray();

            foreach (var type in sceneTypes)
                CoreModule.Scenes.Add(type);

            return application;
        }

        /// <summary>
        /// Use MonoGame providers.
        /// </summary>
        public static IApplication UseMonoGame(this IApplication application, Action<Configuration> configure, Action<Game> action = null)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<InfrastructureModule>();
            containerBuilder.RegisterModule<ProviderModule>();
            containerBuilder.RegisterModule<CoreModule>();
            var container = containerBuilder.Build();

            var internalGame = container.Resolve<InternalGame>();
            container.InjectProperties(application);
            container.InjectProperties(internalGame);

            if (action != null)
                action(internalGame);

            internalGame.Application = application;

            var configuration = new Configuration();
            configure(configuration);

            application.Apply(configuration);

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
                _application.Started += ApplicationStarted;
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
        /// Initializes a new instance of the <see cref="T:FlatSquares.InternalGame"/> class.
        /// </summary>
        public InternalGame()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
        }

        /// <summary>
        /// Application started.
        /// </summary>
        void ApplicationStarted(object sender, EventArgs e)
        {
            Run();
        }

        /// <summary>
        /// Initialize the game
        /// </summary>
        protected override void Initialize()
        {
            ((ContentProvider)ContentProvider).ContentManager = Content;
            ((RenderProvider)RenderProvider).GraphicsDeviceManager = GraphicsDeviceManager;

            Application.StartNavigation();
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