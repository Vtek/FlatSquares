namespace FlatSquares.Common
{
    /// <summary>
    /// Configuration.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// Gets the color of the clear.
        /// </summary>
        /// <value>The color of the clear.</value>
        internal Color ClearColor { get; private set; }

        /// <summary>
        /// Gets the width of the virtual.
        /// </summary>
        /// <value>The width of the virtual.</value>
        internal int VirtualWidth { get; private set; }

        /// <summary>
        /// Gets the height of the virtual.
        /// </summary>
        /// <value>The height of the virtual.</value>
        internal int VirtualHeight { get; private set; }

        /// <summary>
        /// Sets the clear color.
        /// </summary>
        /// <param name="color">Color.</param>
        public void SetClearColor(Color color) => ClearColor = color;

        /// <summary>
        /// Sets the virtual resolution.
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public void SetVirtualResolution(int width, int height)
        {
            VirtualWidth = width;
            VirtualHeight = height;
        }
    }
}