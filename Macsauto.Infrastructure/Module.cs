using Autofac;
using Autofac.Features.ResolveAnything;
using BaseModule = Autofac.Module;

namespace CarWash.Infrastructure
{
    public abstract class Module : BaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
        }
    }
}