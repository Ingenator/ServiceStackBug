using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Windsor.Installers
{
    public abstract class ComponentInstallerBase : IWindsorInstaller
    {
        private string _name;
        public string Name
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._name))
                    this._name = this.GetInstallerName();
                return this._name;
            }
        }

        public abstract void Install(IWindsorContainer container, IConfigurationStore store);

        protected virtual string GetInstallerName()
        {
            return this.GetType().Name;
        }

        protected virtual void LogComponent(ComponentRegistration x)
        {
            System.Diagnostics.Debug.WriteLine("{0} is registering '{1}'", this.Name, x.Implementation.Name);
        }
    }
}