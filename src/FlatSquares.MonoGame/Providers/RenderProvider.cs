using FlatSquares.MonoGame.Extensions;
using FlatSquares.Providers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatSquares.MonoGame.Providers
{
    /// <summary>
    /// Render provider.
    /// </summary>
    class RenderProvider : IRenderProvider
    {
        /// <summary>
        /// Gets or sets the sprite batch.
        /// </summary>
        /// <value>The sprite batch.</value>
        public SpriteBatch SpriteBatch { get; set; }

        /// <summary>
        /// Gets or sets the graphics device manager.
        /// </summary>
        /// <value>The graphics device manager.</value>
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }

        /// <summary>
        /// Gets or sets the matrix.
        /// </summary>
        /// <value>The matrix.</value>
        public Matrix TransformMatrix { get; set; }

        /// <summary>
        /// The clear.
        /// </summary>
        Color _clear = new Color();

        /// <summary>
        /// Gets or sets the clear color.
        /// </summary>
        /// <value>The clear.</value>
        public Common.Color Clear
        {
            get
            {
                return _clear.ToFlatSquareColor();
            }
            set
            {
                _clear = value.ToXnaColor();

            }
        }
        Vector2 _position = new Vector2();
        Vector2 _origin = new Vector2();
        Rectangle _source = new Rectangle();

        /// <summary>
        /// Begin render operation.
        /// </summary>
        public void Begin()
        {
            GraphicsDeviceManager.GraphicsDevice.Clear(_clear);
            SpriteBatch.Begin(transformMatrix: TransformMatrix);
        }

        /// <summary>
        /// Draw operation.
        /// </summary>
        /// <returns>The draw.</returns>
        /// <param name="render">Render.</param>
        public void Draw(IRender render)
        {
            SetPosition(render.Position.X, render.Position.Y);
            SetOrigin(render.Origin.X, render.Origin.Y);
            SetSource(render.Source.X, render.Source.Y, render.Source.Width, render.Source.Height);
            SpriteBatch.Draw((Texture2D)render.Texture, _position, _source, Color.White, render.Rotation, _origin, render.Scale, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// End render operation.
        /// </summary>
        public void End() => SpriteBatch.End();

        /// <summary>
        /// Sets the position.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        void SetPosition(float x, float y)
        {
            _position.X = x;
            _position.Y = y;
        }

        /// <summary>
        /// Sets the origin.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        void SetOrigin(float x, float y)
        {
            _origin.X = x;
            _origin.Y = y;
        }

        /// <summary>
        /// Sets the source.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        void SetSource(float x, float y, float width, float height)
        {
            _source.X = (int)x;
            _source.Y = (int)y;
            _source.Width = (int)width;
            _source.Height = (int)height;
        }
    }
}
