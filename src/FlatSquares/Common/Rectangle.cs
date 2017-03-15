using System;

namespace FlatSquares.Common
{
    /// <summary>
    /// Rectangle.
    /// </summary>
    public struct Rectangle : IEquatable<Rectangle>
    {
        /// <summary>
        /// Gets or sets the x position.
        /// </summary>
        /// <value>The x.</value>
        public float X { get; set; }

        /// <summary>
        /// Gets or sets the y position.
        /// </summary>
        /// <value>The y.</value>
        public float Y { get; set; }

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
        /// Gets the rectangle position.
        /// </summary>
        /// <value>The position.</value>
        public Vector Location => new Vector(X, Y);

        /// <summary>
        /// Gets the rectangle center.
        /// </summary>
        /// <value>The center.</value>
        public Vector Center => new Vector(Right / 2, Bottom / 2);

        /// <summary>
        /// Gets the left.
        /// </summary>
        /// <value>The left.</value>
        public float Left => X;

        /// <summary>
        /// Gets the right.
        /// </summary>
        /// <value>The right.</value>
        public float Right => X + Width;

        /// <summary>
        /// Gets the top.
        /// </summary>
        /// <value>The top.</value>
        public float Top => Y;

        /// <summary>
        /// Gets the bottom.
        /// </summary>
        /// <value>The bottom.</value>
        public float Bottom => Y + Height;

        /// <summary>
        /// Gets a value indicating whether this instance is empty.
        /// </summary>
        /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
        public bool IsEmpty => MathHelper.Abs(X) < float.Epsilon && MathHelper.Abs(Y) < float.Epsilon && MathHelper.Abs(Width) < float.Epsilon && MathHelper.Abs(Height) < float.Epsilon;

        /// <summary>
        /// Gets a empty rectangle.
        /// </summary>
        /// <value>The empty rectangle.</value>
        public static Rectangle Empty { get; } = new Rectangle();

        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public Rectangle(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Contains the specified vector.
        /// </summary>
        /// <param name="v">Vector.</param>
        public bool Contains(Vector v) => (v.X >= X) && (v.X < Right) && (v.Y >= Y) && (v.Y < Bottom);

        /// <summary>
        /// Contains the specified rectangle.
        /// </summary>
        /// <param name="r">The rectangle.</param>
        public bool Contains(Rectangle r) => (r.X >= X) && (r.Right < Right) && (r.Y >= Y) && (r.Bottom < Bottom);

        /// <summary>
        /// Intersects the specified rectangle.
        /// </summary>
        /// <param name="r">The rectangle component.</param>
        public bool Intersects(Rectangle r) => (r.X < Right) && (r.Right > X) && (r.Y < Bottom) && (r.Bottom > Y);

        /// <summary>
        /// Union the specified r1 and r2.
        /// </summary>
        /// <param name="r1">R1.</param>
        /// <param name="r2">R2.</param>
        public static Rectangle Union(Rectangle r1, Rectangle r2)
        {
            var x = (r1.X < r2.X) ? r1.X : r2.X;
            var y = (r1.Y < r2.Y) ? r1.Y : r2.Y;
            var width = ((r1.Right > r2.Right) ? r1.Right : r2.Right) - x;
            var height = ((r1.Bottom > r2.Bottom) ? r1.Bottom : r2.Bottom) - y;
            return new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Clone this instance.
        /// </summary>
        public Rectangle Clone() => new Rectangle(X, Y, Width, Height);

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Rectangle"/>.</param>
        /// <returns><c>true</c> if the specified object is equal to the current <see cref="Rectangle"/>;
        /// otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => (obj is Rectangle) && Equals((Rectangle)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Rectangle"/> is equal to the current <see cref="Rectangle"/>.
        /// </summary>
        /// <param name="other">The <see cref="Rectangle"/> to compare with the current <see cref="Rectangle"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Rectangle"/> is equal to the current
        /// <see cref="Rectangle"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(Rectangle other) => MathHelper.Abs(X - other.X) < float.Epsilon && MathHelper.Abs(Y - other.Y) < float.Epsilon && MathHelper.Abs(Width - other.Width) < float.Epsilon && MathHelper.Abs(Height - other.Height) < float.Epsilon;

        /// <summary>
        /// Serves as a hash function for a <see cref="Rectangle"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var result = X.GetHashCode();
                result = (result * 397) ^ Y.GetHashCode();
                result = (result * 397) ^ Width.GetHashCode();
                result = (result * 397) ^ Height.GetHashCode();
                return result;
            }
        }
    }
}
