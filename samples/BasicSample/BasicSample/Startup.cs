using FlatSquares;
using FlatSquares.Common;
using Microsoft.Xna.Framework;

namespace BasicSample
{
	public static class Startup
	{
        public static void Launch(IApplication application)
        {
            application
                .UseMonoGame(SetConfiguration, SetupMonoGame)
				.Start<RootScene>();
		}

        static void SetConfiguration(Configuration configuration)
        {
            configuration.SetClearColor(FlatSquares.Common.Color.Black);
            configuration.SetVirtualResolution(1280, 720);
        }

        static void SetupMonoGame(Game game)
        {
            game.Content.RootDirectory = "Content";
        }
	}
}
