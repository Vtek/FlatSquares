using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using FlatSquares.Core;

namespace FlatSquares.MonoGame.Dependencies.Modules
{
    class CoreModule : Autofac.Module
    {
        /// <summary>
        /// Load the module.
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SceneFactory>().As<ISceneFactory>().SingleInstance();
            builder.RegisterType<Navigation>().As<INavigation>().SingleInstance();

            foreach (var assembly in GetAssemblies())
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

        private IEnumerable<Assembly> GetAssemblies()
        {
            //Ugly code but there is no other way to retreive assemblies meta information
            var appDomain = typeof(string).GetTypeInfo().Assembly.GetType("System.AppDomain").GetRuntimeProperty("CurrentDomain").GetMethod.Invoke(null, new object[] { });
            var getAssembliesMethod = appDomain.GetType().GetRuntimeMethod("GetAssemblies", new System.Type[] { });
            return getAssembliesMethod.Invoke(appDomain, new object[] { }) as Assembly[];
        }
    }
}
