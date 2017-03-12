using System.Linq;
using Autofac;
using FlatSquares.Core;

namespace FlatSquares.MonoGame
{
	public class GameModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<ContentProvider>().As<IContentProvider>().SingleInstance();
			builder.RegisterType<RenderProvider>().As<IRenderProvider>().SingleInstance();
			builder.RegisterType<DependencyContainer>().As<IDependencyContainer>().SingleInstance();
			builder.RegisterType<SceneFactory>().As<ISceneFactory>().SingleInstance();
			builder.RegisterType<Navigation>().As<INavigation>().SingleInstance();

			foreach (var assembly in AppDomain.Assemblies) 
			{ 
				builder
					.RegisterTypes(assembly.DefinedTypes
									  .Where(type => type.ImplementedInterfaces.Any(i => i.Name == typeof(IScene).Name))
									  .Select(type => type.AsType())
									  .ToArray())
					.OnActivated(e => e.Context.InjectUnsetProperties(e.Instance));
			}
		}
	}
}
