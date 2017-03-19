using System;
using System.Linq;
using System.Reflection;
using Autofac;
using FlatSquares.Common;
using FlatSquares.MonoGame.Modules;
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

            internalGame.TransformMatrix = new TransformMatrix
            {
                VirtualWidth = configuration.VirtualWidth,
                VirtualHeight = configuration.VirtualHeight
            };

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
        /// Gets or sets the transform matrix.
        /// </summary>
        /// <value>The transform matrix.</value>
        public TransformMatrix TransformMatrix { get; set; }

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
        /// Gets or sets the touch provider.
        /// </summary>
        /// <value>The touch provider.</value>
        public ITouchProvider TouchProvider { get; set; }

        public IVirtualResolutionProvider VirtualResolutionProvider { get; set; }

        /// <summary>
        /// Gets or sets the graphics device manager.
        /// </summary>
        /// <value>The graphics device manager.</value>
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }

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
            GraphicsDeviceManager.PreferredBackBufferWidth = (int)TransformMatrix.VirtualWidth;
            GraphicsDeviceManager.PreferredBackBufferHeight = (int)TransformMatrix.VirtualHeight;

            TransformMatrix.Width = GraphicsDevice.Viewport.Width;
            TransformMatrix.Height = GraphicsDevice.Viewport.Height;
            TransformMatrix.Initialize();

            var contentProvider = ContentProvider as ContentProvider;
            contentProvider.ContentManager = Content;

            var renderProvider = RenderProvider as RenderProvider;
            renderProvider.GraphicsDeviceManager = GraphicsDeviceManager;
            renderProvider.TransformMatrix = TransformMatrix;

            var touchProvider = TouchProvider as TouchProvider;
            touchProvider.TransformMatrix = Matrix.Invert(TransformMatrix);

            var virtualResolutionProvider = VirtualResolutionProvider as VirtualResolutionProvider;
            virtualResolutionProvider.Width = TransformMatrix.VirtualWidth;
            virtualResolutionProvider.Height = TransformMatrix.VirtualHeight;

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

    /// <summary>
    /// Transform matrix.
    /// </summary>
    class TransformMatrix
    {
        /// <summary>
        /// Gets or sets the width of the virtual.
        /// </summary>
        /// <value>The width of the virtual.</value>
        public float VirtualWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the virtual.
        /// </summary>
        /// <value>The height of the virtual.</value>
        public float VirtualHeight { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public float Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public float Height { get; set; }

        /// <summary>
        /// Gets or sets the matrix.
        /// </summary>
        /// <value>The matrix.</value>
        Matrix Matrix { get; set; }

        /// <summary>
        /// Initialize this instance.
        /// </summary>
        public void Initialize() => Matrix = Matrix.CreateScale(Width / VirtualWidth, Height / VirtualHeight, 1.0f);

        public static implicit operator Matrix(TransformMatrix tm) => tm.Matrix;
    }
}