using Microsoft.Xna.Framework;

namespace FlatSquares.MonoGame.Extensions
{
    /// <summary>
    /// Color extension.
    /// </summary>
    static class ColorExtension
    {
        /// <summary>
        /// Convert an Xna color to a FlatSquare color.
        /// </summary>
        public static Common.Color ToFlatSquareColor(this Color color) => new Common.Color(color.R, color.G, color.B, color.A);

        /// <summary>
        /// Convert an FlatSquare color to a Xna color.
        /// </summary>
        public static Color ToXnaColor(this Common.Color color) => new Color(color.R, color.G, color.B, color.A);
    }
}
