using Autofac;

namespace FlatSquares.MonoGame.Modules
{
    /// <summary>
    /// Infrastructure module.
    /// </summary>
    public class InfrastructureModule : Module
    {
        /// <summary>
        /// Load the module.
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DependencyContainer>().As<IDependencyContainer>().SingleInstance();
            base.Load(builder);
        }
    }
}
