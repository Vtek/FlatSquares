using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatSquares.MonoGame
{
	public class RenderProvider : IRenderProvider
	{
		public SpriteBatch SpriteBatch { get; set; }
		public GraphicsDeviceManager GraphicsDeviceManager { get; set; }

		Color _clearColor = new Color();
		bool _clearColorDefined;

		Color _drawColor = new Color();
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
			SpriteBatch.Begin(SpriteSortMode.Immediate);
		}

		public void Draw(IRender render)
		{
			throw new NotImplementedException();
		}

		public void End()
		{
			SpriteBatch.End();
		}
	}
}
