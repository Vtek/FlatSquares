using Autofac;
using FlatSquares.MonoGame.Providers;

namespace FlatSquares.MonoGame.Dependencies.Modules
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
            base.Load(builder);
        }
    }
}
