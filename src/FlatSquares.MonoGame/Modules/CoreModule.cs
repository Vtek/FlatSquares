using System;
using System.Collections.Generic;
using Autofac;
using FlatSquares.Core;

namespace FlatSquares.MonoGame.Modules
{
    class CoreModule : Autofac.Module
    {
        internal static IList<Type> Scenes { get; set; } = new List<Type>();

        /// <summary>
        /// Load the module.
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SceneFactory>().As<ISceneFactory>().SingleInstance();
            builder.RegisterType<Navigation>().As<INavigation>().SingleInstance();

            Scenes.ForEach(scene => builder.RegisterTypes(scene).OnActivated(e => e.Context.InjectUnsetProperties(e.Instance)));

            base.Load(builder);
        }
    }
}
