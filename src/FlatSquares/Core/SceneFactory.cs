using FlatSquares.Providers;

namespace FlatSquares.Core
{
    /// <summary>
    /// Scene factory.
    /// </summary>
    public class SceneFactory : ISceneFactory
    {
        /// <summary>
        /// Gets or sets the dependency provider.
        /// </summary>
        /// <value>The dependency provider.</value>
        IDependencyProvider DependencyProvider { get; set; }

        /// <summary>
        /// Gets or sets the loading scene.
        /// </summary>
        /// <value>The loading.</value>
        public IScene Loading { get; private set; }

        /// <summary>
        /// Gets or sets the root.
        /// </summary>
        /// <value>The root.</value>
        public IScene Root { get; private set; }

        /// <summary>
        /// Gets or sets the splash.
        /// </summary>
        /// <value>The splash.</value>
        public ISplash Splash { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FlatSquares.Core.SceneFactory"/> class.
        /// </summary>
        /// <param name="dependencyProvider">Dependency provider.</param>
        public SceneFactory(IDependencyProvider dependencyProvider)
        {
            DependencyProvider = dependencyProvider;
        }

        /// <summary>
        /// Create a scene.
        /// </summary>
        /// <returns>Scene.</returns>
        /// <typeparam name="TScene">Scene type to create.</typeparam>
        public TScene Create<TScene>() where TScene : IScene
            =>
                DependencyProvider.GetInstance<TScene>();

        /// <summary>
        /// Sets the splash scene.
        /// </summary>
        /// <typeparam name="TScene">Splash scene type.</typeparam>
        public void SetSplash<TScene>() where TScene : ISplash
            =>
                Splash = DependencyProvider.GetInstance<TScene>();

        /// <summary>
        /// Sets the loading scene. 
        /// </summary>
        /// <typeparam name="TScene">Loading scene type.</typeparam>
        public void SetLoading<TScene>() where TScene : IScene
            =>
                Loading = DependencyProvider.GetInstance<TScene>();

        /// <summary>
        /// Sets the root scene.
        /// </summary>
        /// <typeparam name="TScene">Root scene type.</typeparam>
        public void SetRoot<TScene>() where TScene : IScene
            =>
                Root = DependencyProvider.GetInstance<TScene>();
    }
}
