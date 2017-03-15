using System;

namespace FlatSquares.Common
{
    /// <summary>
    /// Color.
    /// </summary>
    public struct Color : IEquatable<Color>
    {
        /// <summary>
        /// Gets or sets alpha.
        /// </summary>
        /// <value>Alpha.</value>
        public byte A { get; set; }

        /// <summary>
        /// Gets or sets the red.
        /// </summary>
        /// <value>The red.</value>
        public byte R { get; set; }

        /// <summary>
        /// Gets or sets the green.
        /// </summary>
        /// <value>The green.</value>
        public byte G { get; set; }

        /// <summary>
        /// Gets or sets the blue.
        /// </summary>
        /// <value>The blue.</value>
        public byte B { get; set; }

        /// <summary>
        /// Gets the black color.
        /// </summary>
        /// <value>The black color.</value>
        public static Color Black { get; } = new Color(0, 0, 0);

        /// <summary>
        /// Gets the white color.
        /// </summary>
        /// <value>The white color.</value>
        public static Color White { get; } = new Color(255, 255, 255);

        /// <summary>
        /// Gets the red color.
        /// </summary>
        /// <value>The red color.</value>
        public static Color Red { get; } = new Color(255, 0, 0);

        /// <summary>
        /// Gets the green color.
        /// </summary>
        /// <value>The green color.</value>
        public static Color Green { get; } = new Color(255, 0, 0);

        /// <summary>
        /// Gets the blue color.
        /// </summary>
        /// <value>The blue color.</value>
        public static Color Blue { get; } = new Color(0, 0, 255);

        /// <summary>
        /// Gets the yellow color.
        /// </summary>
        /// <value>The yellow color.</value>
        public static Color Yellow { get; } = new Color(255, 255, 0);

        /// <summary>
        /// Gets the magenta color.
        /// </summary>
        /// <value>The magenta color.</value>
        public static Color Magenta { get; } = new Color(255, 0, 255);

        /// <summary>
        /// Gets the cyan color.
        /// </summary>
        /// <value>The cyan color.</value>
        public static Color Cyan { get; } = new Color(0, 255, 255);

        /// <summary>
        /// Gets the transparent color.
        /// </summary>
        /// <value>The transparent color.</value>
        public static Color Transparent { get; } = new Color(0, 0, 0, 0);


        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> class.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        public Color(byte r, byte g, byte b)
                : this(r, g, b, 255)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> class.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public Color(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        /// <summary>
        /// Clone this instance.
        /// </summary>
        public Color Clone() => new Color(R, G, B, A);

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Color"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current <see cref="Color"/>.</param>
        /// <returns><c>true</c> if the specified object is equal to the current <see cref="Color"/>;
        /// otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => (obj is Color) && Equals((Color)obj);

        /// <summary>
        /// Determines whether the specified <see cref="Color"/> is equal to the current <see cref="Color"/>.
        /// </summary>
        /// <param name="other">The <see cref="Color"/> to compare with the current <see cref="Color"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="Color"/> is equal to the current <see cref="Color"/>;
        /// otherwise, <c>false</c>.</returns>
        public bool Equals(Color other) => A == other.A && R == other.R && G == other.G && B == other.B;

        /// <summary>
        /// Serves as a hash function for a <see cref="Color"/> object.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var result = A.GetHashCode();
                result = (result * 397) ^ R.GetHashCode();
                result = (result * 397) ^ G.GetHashCode();
                result = (result * 397) ^ B.GetHashCode();
                return result;
            }
        }

        /// <summary>
        /// Lerp the color on rgb.
        /// </summary>
        /// <returns>The rgb lerp color.</returns>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="amount">Amount.</param>
        public static Color LerpRgb(Color value1, Color value2, float amount) => new Color((byte)MathHelper.Lerp(value1.R, value2.R, amount), (byte)MathHelper.Lerp(value1.G, value2.G, amount), (byte)MathHelper.Lerp(value1.B, value2.B, amount));

        /// <summary>
        /// Lerp the color on argb.
        /// </summary>
        /// <returns>The argb color.</returns>
        /// <param name="value1">Value1.</param>
        /// <param name="value2">Value2.</param>
        /// <param name="amount">Amount.</param>
        public static Color LerpArgb(Color value1, Color value2, float amount) => new Color((byte)MathHelper.Lerp(value1.R, value2.R, amount), (byte)MathHelper.Lerp(value1.G, value2.G, amount), (byte)MathHelper.Lerp(value1.B, value2.B, amount), (byte)MathHelper.Lerp(value1.A, value2.A, amount));

        public static bool operator ==(Color c1, Color c2) => c1.Equals(c2);
        public static bool operator !=(Color c1, Color c2) => !c1.Equals(c2);
    }
}
