using Autofac;

namespace FlatSquares.MonoGame
{
	public class DependencyContainer : IDependencyContainer
	{
		ILifetimeScope Container { get; }

		public DependencyContainer(ILifetimeScope container)
		{
			Container = container;
		}

		public void Dispose()
		{
			Container.Dispose();
		}

		public TType GetInstance<TType>()
		{
			return Container.Resolve<TType>();
		}
	}
}
