using Microsoft.Xna.Framework.Content;

namespace FlatSquares.MonoGame.Providers
{
    class ContentProvider : IContentProvider
    {
        public ContentManager ContentManager { get; set; }

        public object Load(string resourcePath)
        {
            return ContentManager.Load<object>(resourcePath);
        }
    }
}
