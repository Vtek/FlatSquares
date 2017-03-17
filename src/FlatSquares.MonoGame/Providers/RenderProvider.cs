using FlatSquares.Providers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatSquares.MonoGame.Providers
{
    class RenderProvider : IRenderProvider
    {
        public SpriteBatch SpriteBatch { get; set; }
        public GraphicsDeviceManager GraphicsDeviceManager { get; set; }

        Color _clearColor = new Color();
        bool _clearColorDefined;

        Color _drawColor = Color.White;
        Vector2 _position = new Vector2();
        Vector2 _origin = new Vector2();
        Rectangle _source = new Rectangle();

        public int HeightRequired { get; set; }
        public int WidthRequired { get; set; }

        public void Begin(Common.Color color)
        {
            if (_clearColorDefined)
            {
                _clearColor.A = color.A;
                _clearColor.B = color.B;
                _clearColor.G = color.G;
                _clearColor.R = color.R;
                _clearColorDefined = true;
            }

            GraphicsDeviceManager.GraphicsDevice.Clear(_clearColor);
            SpriteBatch.Begin();
        }

        public void Draw(IRender render)
        {
            _position.X = render.Position.X;
            _position.Y = render.Position.Y;

            _source.X = (int)render.Source.X;
            _source.Y = (int)render.Source.Y;
            _source.Width = (int)render.Source.Width;
            _source.Height = (int)render.Source.Height;

            _origin.X = render.Origin.X;
            _origin.Y = render.Origin.Y;

            SpriteBatch.Draw(render.GetRenderObject<Texture2D>(), _position, _source, _drawColor, render.Rotation, _origin, render.Scale, SpriteEffects.None, 0f);
        }

        public void End()
        {
            SpriteBatch.End();
        }
    }
}
