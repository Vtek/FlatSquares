using Autofac;
using FlatSquares.Core;

namespace FlatSquares.MonoGame.Modules
{
    public class CoreModule : Module
    {
        /// <summary>
        /// Load the module.
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SceneFactory>().As<ISceneFactory>().SingleInstance();
            builder.RegisterType<Navigation>().As<INavigation>().SingleInstance();

            foreach (var assembly in AppDomain.Assemblies)
            {
                if (!assembly.FullName.StartsWith("Xamarin"))
                {
                    builder
                        .RegisterTypes(assembly.DefinedTypes
                                      .Where(type => type.ImplementedInterfaces.Any(i => i.Name == typeof(IScene).Name))
                                      .Select(type => type.AsType())
                                      .ToArray())
                        .OnActivated(e => e.Context.InjectUnsetProperties(e.Instance));
                }
            }
            base.Load(builder);
        }
    }
}
