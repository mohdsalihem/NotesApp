using Autofac;
using NotesApp.Server.Repositories;
using NotesApp.Server.Repositories.Interfaces;
using System.Reflection;

namespace NotesApp.Server.Helpers
{
    public class AutofacRegisterModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
        }
    }
}
