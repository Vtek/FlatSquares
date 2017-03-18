using FlatSquares.Common;

namespace FlatSquares.Providers
{
    /// <summary>
    /// Define a touch provider.
    /// </summary>
    public interface ITouchProvider : IActive
    {
        /// <summary>
        /// True if passing finger index is down.
        /// </summary>
        /// <returns>True if passing finger index is down.</returns>
        /// <param name="index">Finger index.</param>
        bool Down(int index);

        /// <summary>
        /// True if passing finger index is up.
        /// </summary>
        /// <returns>True if passing finger index is up.</returns>
        /// <param name="index">Finger index.</param>
        bool Up(int index);

        /// <summary>
        /// True if passing finger index was pressed.
        /// </summary>
        /// <returns>True if passing finger index was pressed.</returns>
        /// <param name="index">Finger index.</param>
        bool Pressed(int index);

        /// <summary>
        /// True if passing finger index was released.
        /// </summary>
        /// <returns>True if passing finger index was released.</returns>
        /// <param name="index">Finger index.</param>
        bool Released(int index);

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <returns>The position.</returns>
        /// <param name="index">Finger index.</param>
        Vector GetPosition(int index);

        /// <summary>
        /// Gets the last position.
        /// </summary>
        /// <returns>The last position.</returns>
        /// <param name="index">FInger index.</param>
        Vector GetLastPosition(int index);

        /// <summary>
        /// Refresh touches states.
        /// </summary>
        void Refresh();
    }
}
