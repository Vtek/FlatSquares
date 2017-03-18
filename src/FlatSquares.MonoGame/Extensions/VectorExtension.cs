using Microsoft.Xna.Framework;

namespace FlatSquares.MonoGame.Extensions
{
    /// <summary>
    /// Vector extension.
    /// </summary>
    static class VectorExtension
    {
        /// <summary>
        /// Convert an Xna Vector2d to a FlatSquare Vector.
        /// </summary>
        public static Common.Vector ToFlatSquareVector(this Vector2 vector) => new Common.Vector(vector.X, vector.Y);
    }
}
