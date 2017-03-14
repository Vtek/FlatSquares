using Autofac;
using FlatSquares.MonoGame;
using FlatSquares.MonoGame.Modules;

namespace FlatSquares
{
	public static class ApplicationExtension
	{
		static FSGame game;

		public static IApplication UseMonoGame(this IApplication application)
		{
			var containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterModule<InfrastructureModule>();
            containerBuilder.RegisterModule<ProviderModule>();
            containerBuilder.RegisterModule<CoreModule>();
			var container = containerBuilder.Build();

			container.InjectProperties(application);

			var contentProvider = container.Resolve<IContentProvider>();
			var renderProivder = container.Resolve<IRenderProvider>();

			game = new FSGame(application, contentProvider, renderProivder);

			return application;
		}
	}
}
