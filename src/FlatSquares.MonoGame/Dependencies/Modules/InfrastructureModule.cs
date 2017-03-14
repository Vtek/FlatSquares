using Autofac;

namespace FlatSquares.MonoGame.Dependencies.Modules
{
    /// <summary>
    /// Infrastructure module.
    /// </summary>
    class InfrastructureModule : Module
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
