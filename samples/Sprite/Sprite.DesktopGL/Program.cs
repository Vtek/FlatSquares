using System;
using FlatSquares.Core;
using FlatSquares.Common;
using Microsoft.Xna.Framework;

namespace Sprite.DesktopGL
{
    static class Program
    {
        internal static void RunGame()
        {
            Launcher.Application
                    .RegisterScenes(typeof(RootScene).Assembly)
                    .UseMonoGame(SetConfiguration, SetupMonoGame)
                    .Start<RootScene>();
            Launcher.Application.Dispose();
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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RunGame();
        }
    }
}
