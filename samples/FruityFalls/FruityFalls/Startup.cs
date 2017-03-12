using FlatSquares;
using FlatSquares.Common;

namespace FruityFalls
{
	public class Startup
	{
		public static void Launch(IApplication application)
		{
			application
				//.UseMonoGame()
				.SetContentRootPath("Content")
				.SetClearColor(Color.Black)
				.SetVirtualResolution(1280, 720)
				.Start<RootScene>();
		}
	}
}
