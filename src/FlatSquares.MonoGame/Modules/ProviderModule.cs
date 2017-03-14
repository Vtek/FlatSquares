using Autofac;

namespace FlatSquares.MonoGame.Modules
{
    /// <summary>
    /// Provider module.
    /// </summary>
    public class ProviderModule : Module
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
