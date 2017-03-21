using FlatSquares.Common;
using FlatSquares.Core;
using Foundation;
using Microsoft.Xna.Framework;
using SceneNavigation.Scenes;
using UIKit;

namespace SceneNavigation.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override void FinishedLaunching(UIApplication application)
        {
            Launcher.Application
                    .RegisterScenes(typeof(FirstScene).Assembly)
                    .UseMonoGame(SetConfiguration, SetupMonoGame)
                    .Start<FirstScene>();
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

