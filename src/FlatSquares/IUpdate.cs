namespace FlatSquares
{
    /// <summary>
    /// Define update behavior
    /// </summary>
    public interface IUpdate
    {
        /// <summary>
        /// Perform an update.
        /// </summary>
        /// <param name="elapsed">Elapsed time since last update.</param>
        void Update(float elapsed);
    }
}
