using FlatSquares.Common;
using FlatSquares.Core;
using Foundation;
using Microsoft.Xna.Framework;
using SpriteAnimation.Scenes;
using UIKit;

namespace SpriteAnimation.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override void FinishedLaunching(UIApplication application)
        {
            Launcher.Application
                    .RegisterScenes(typeof(RootScene).Assembly)
                    .UseMonoGame(SetConfiguration, SetupMonoGame)
                    .Start<RootScene>();
        }

        static void SetConfiguration(Configuration configuration)
        {
            configuration.ClearColor = FlatSquares.Common.Color.Black;
            configuration.VirtualWidth = 854;
            configuration.VirtualHeight = 480;
        }

        static void SetupMonoGame(Game game)
        {
            game.Content.RootDirectory = "Content";
        }
    }
}

