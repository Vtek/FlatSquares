using System;
using Microsoft.Xna.Framework.Content;

namespace FlatSquares.MonoGame
{
	public class ContentProvider : IContentProvider
	{
		public ContentManager ContentManager { get; set; }

		public string RootPath
		{
			get
			{
				return ContentManager.RootDirectory;
			}
			set
			{
				ContentManager.RootDirectory = value;
			}
		}

		public object Load(string resourcePath)
		{
			return ContentManager.Load<object>(resourcePath);
		}
	}
}
