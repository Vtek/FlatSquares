using FlatSquares.Common;
using FlatSquares.MonoGame.Extensions;
using FlatSquares.Providers;
using Microsoft.Xna.Framework.Input.Touch;

namespace FlatSquares.MonoGame.Providers
{
    /// <summary>
    /// Touch provider.
    /// </summary>
    public class TouchProvider : ITouchProvider
    {
        TouchCollection _current;
        TouchCollection _last;

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:FlatSquares.IActive"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active => TouchPanel.GetCapabilities().IsConnected;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:FlatSquares.MonoGame.Providers.TouchProvider"/> class.
        /// </summary>
        public TouchProvider()
        {
            _current = TouchPanel.GetState();
        }

        /// <summary>
        /// True if passing finger index is down.
        /// </summary>
        /// <returns>True if passing finger index is down.</returns>
        /// <param name="index">Finger index.</param>
        public bool Down(int index) => _current[index].State == TouchLocationState.Pressed;

        /// <summary>
        /// True if passing finger index is up.
        /// </summary>
        /// <returns>True if passing finger index is up.</returns>
        /// <param name="index">Finger index.</param>
        public bool Up(int index) => _current[index].State == TouchLocationState.Released;

        /// <summary>
        /// True if passing finger index was pressed.
        /// </summary>
        /// <returns>True if passing finger index was pressed.</returns>
        /// <param name="index">Finger index.</param>
        public bool Pressed(int index) => _current[index].State == TouchLocationState.Pressed && _last[index].State == TouchLocationState.Released;

        /// <summary>
        /// True if passing finger index was released.
        /// </summary>
        /// <returns>True if passing finger index was released.</returns>
        /// <param name="index">Finger index.</param>
        public bool Released(int index) => _current[index].State == TouchLocationState.Released && _last[index].State == TouchLocationState.Pressed;

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns>The position.</returns>
        /// <param name="index">Finger index.</param>
        public Vector GetPosition(int index) => _current[index].Position.ToFlatSquareVector();

        /// <summary>
        /// Gets the last position.
        /// </summary>
        /// <returns>The last position.</returns>
        /// <param name="index">FInger index.</param>
        public Vector GetLastPosition(int index) => _last[index].Position.ToFlatSquareVector();

        /// <summary>
        /// Refresh touches states.
        /// </summary>
        public void Refresh()
        {
            _last = _current;
            _current = TouchPanel.GetState();
        }
    }
}
