using System;

namespace FlatSquares
{
    /// <summary>
    /// Define game navigation
    /// </summary>
    public interface INavigation : IDisposable
    {
        /// <summary>
        /// Push a Scene into the navigation stack.
        /// </summary>
        /// <param name="parameter">Optinal parameter</param>
        void Push<TScene>(object parameter = null) where TScene : IScene;

        /// <summary>
        /// Remove the top Scene in the navigation stack.
        /// </summary>
        /// <returns>The pop.</returns>
        void Pop();

        /// <summary>
        /// Pops all but the root scene off the navigation stack.
        /// </summary>
        /// <returns>The to root.</returns>
        void PopToRoot();

        /// <summary>
        /// Start.
        /// </summary>
        void Start();

        /// <summary>
        /// Gets the current scene.
        /// </summary>
        /// <returns>The current scene.</returns>
        IScene GetCurrent();
    }
}
