using FlatSquares;
using FlatSquares.Common;

namespace BasicSample
{
	public static class Startup
	{
		public static void Launch(IApplication application)
		{
			application
				.UseMonoGame()
				.SetContentRootPath("Content")
				.SetClearColor(Color.Black)
				.SetVirtualResolution(1280, 720)
				.Start<RootScene>();
		}
	}
}
