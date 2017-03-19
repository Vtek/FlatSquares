using Autofac;
using FlatSquares.Core;
using FlatSquares.MonoGame.Providers;
using FlatSquares.Providers;

namespace FlatSquares.MonoGame.Modules
{
    /// <summary>
    /// Provider module.
    /// </summary>
    class ProviderModule : Module
    {
        /// <summary>
        /// Load the module.
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentProvider>().As<IContentProvider>().SingleInstance();
            builder.RegisterType<RenderProvider>().As<IRenderProvider>().SingleInstance();
            builder.RegisterType<DependencyProvider>().As<IDependencyProvider>().SingleInstance();
            builder.RegisterType<TouchProvider>().As<ITouchProvider>().SingleInstance();
            builder.RegisterType<VirtualResolutionProvider>().As<IVirtualResolutionProvider>().SingleInstance();

            builder.RegisterType<InternalGame>().AsSelf().SingleInstance();
            base.Load(builder);
        }
    }
}
