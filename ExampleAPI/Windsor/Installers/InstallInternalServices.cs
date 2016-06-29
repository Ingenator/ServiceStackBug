using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Example.Services.InternalService;

namespace Example.Windsor.Installers
{
    public class InstallInternalServices : ComponentInstallerBase, IWindsorInstaller
    {
        public override void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyInDirectory(new ApplicationAssemblyFilter())
                .IncludeNonPublicTypes()
                .BasedOn<IInternalService>()
                .Configure(x => this.LogComponent(x))
                .WithServiceFromInterface(typeof(IInternalService)));
        }
    }
}