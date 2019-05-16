using System.Reflection;
using Autofac;
using MV.Domain.Models;
using Module = Autofac.Module;

namespace MV.Domain.InjectionModules
{
    public class IoCModuleDomain : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assemblyToScan = Assembly.GetAssembly(typeof(User));

            builder
                .RegisterAssemblyTypes(assemblyToScan)
                .Where(c => c.IsClass
                            && c.IsInNamespace("MV.Domain.CommandHandlers"))
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(assemblyToScan)
                .Where(c => c.IsClass
                            && c.IsInNamespace("MV.Domain.Commands"))
                .AsImplementedInterfaces();
        }
    }
}
