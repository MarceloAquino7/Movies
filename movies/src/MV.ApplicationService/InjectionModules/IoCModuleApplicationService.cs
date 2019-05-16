using System.Reflection;
using Autofac;
using MV.ApplicationService.Services;
using MV.Domain.InjectionModules;
using MV.Common.WebServer.Server;
using Module = Autofac.Module;

namespace MV.ApplicationService.InjectionModules
{
    public class IoCModuleApplicationService : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Domain Modules: Command and CommandHandlers
            builder.RegisterModule<IoCModuleDomain>();

            var assemblyToScan = Assembly.GetAssembly(typeof(BaseAppService));

            builder
                .RegisterAssemblyTypes(assemblyToScan)
                .Where(c => c.IsClass
                            && c.IsInNamespace("MV.ApplicationService.Services"))
                .AsImplementedInterfaces();

            builder.RegisterType<UserContext>().AsSelf();
        }
    }
}
