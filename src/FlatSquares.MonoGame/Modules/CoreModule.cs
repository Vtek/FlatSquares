using System;
using System.Collections.Generic;
using Autofac;
using FlatSquares.Core;

namespace FlatSquares.MonoGame.Modules
{
    /// <summary>
    /// Core module.
    /// </summary>
    class CoreModule : Module
    {
        /// <summary>
        /// Gets or sets the scenes.
        /// </summary>
        /// <value>The scenes.</value>
        internal static IList<Type> Scenes { get; private set; } = new List<Type>();

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
