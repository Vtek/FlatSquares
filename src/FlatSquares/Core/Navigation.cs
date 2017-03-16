using System;
using System.Collections.Generic;
using System.Linq;

namespace FlatSquares.Core
{
    /// <summary>
    /// Navigation.
    /// </summary>
    public class Navigation : INavigation
    {
        /// <summary>
        /// Gets or sets the scenes.
        /// </summary>
        /// <value>The scenes.</value>
        IList<IScene> Scenes { get; set; } = new List<IScene>();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:FlatSquares.SceneFactory"/> is started.
        /// </summary>
        /// <value><c>true</c> if is started; otherwise, <c>false</c>.</value>
        bool Started { get; set; }

        /// <summary>
        /// Gets or sets the scene factory.
        /// </summary>
        /// <value>The scene factory.</value>
        ISceneFactory SceneFactory { get; set; }

        /// <summary>
        /// Gets or sets the content provider.
        /// </summary>
        /// <value>The content provider.</value>
        IContentProvider ContentProvider { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FlatSquares.Core.Navigation"/> class.
        /// </summary>
        /// <param name="sceneFactory">Scene factory.</param>
        /// <param name="contentProvider">Content provider.</param>
        public Navigation(ISceneFactory sceneFactory, IContentProvider contentProvider)
        {
            SceneFactory = sceneFactory;
            ContentProvider = contentProvider;
        }

        /// <summary>
        /// Remove the top Scene in the navigation stack.
        /// </summary>
        /// <returns>The pop.</returns>
        public void Pop()
        {
            if (Current.GetType() != SceneFactory.Root.GetType())
            {
                Current.Dispose();
                Scenes.Remove(Current);
                Scenes.Last().Enabled = true;
            }
        }

        /// <summary>
        /// Pops all but the root scene off the navigation stack.
        /// </summary>
        /// <returns>The to root.</returns>
        public void PopToRoot()
        {
            Scenes.ForEach(scene =>
            {
                if (scene.GetType() != SceneFactory.Root.GetType())
                    scene.Dispose();
            });

            Scenes.Clear();

            SceneFactory.Root.Create();
            SceneFactory.Root.Initialize();

            Scenes.Add(SceneFactory.Root);
            SceneFactory.Root.Enabled = true;
        }

        /// <summary>
        /// Push a Scene into the navigation stack.
        /// </summary>
        /// <param name="parameter">Optinal parameter</param>
        public void Push<TScene>(object parameter = null) where TScene : IScene
        {
            var scene = SceneFactory.Create<TScene>();
            scene.Create(parameter);
            scene.Initialize();

            if (Current != null)
                Current.Enabled = false;

            Scenes.Add(scene);
        }

        /// <summary>
        /// Gets the current scene.
        /// </summary>
        /// <returns>The current.</returns>
        public IScene Current => Scenes.LastOrDefault();

        /// <summary>
        /// Start.
        /// </summary>
        public void Start()
        {
            if (Started)
                throw new InvalidOperationException();

            if (SceneFactory.Splash != null)
            {
                SceneFactory.Splash.Create();
                SceneFactory.Splash.Initialize();
                SceneFactory.Splash.Finished += SplashFinished;
                Scenes.Add(SceneFactory.Splash);
            }
            else
            {
                PopToRoot();
            }
        }

        /// <summary>
        /// Handle splash finished event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void SplashFinished(object sender, EventArgs e)
        {
            SceneFactory.Splash.Finished -= SplashFinished;
            PopToRoot();
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:FlatSquares.Navigation"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:FlatSquares.Navigation"/>. The
        /// <see cref="Dispose"/> method leaves the <see cref="T:FlatSquares.Navigation"/> in an unusable state. After calling
        /// <see cref="Dispose"/>, you must release all references to the <see cref="T:FlatSquares.Navigation"/> so the
        /// garbage collector can reclaim the memory that the <see cref="T:FlatSquares.Navigation"/> was occupying.</remarks>
        public void Dispose() => Scenes.ForEach(scene => scene.Dispose());
    }
}
