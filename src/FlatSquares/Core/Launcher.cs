namespace FlatSquares.Core
{
    /// <summary>
    /// FlatSquares launcher.
    /// </summary>
    public static class Launcher
    {
        /// <summary>
        /// Single application instance
        /// </summary>
        static IApplication _application = new Application();

        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <value>The application.</value>
        public static IApplication Application => _application;
    }
}
