using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ServiceStack.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Windsor
{
    /// <summary>
    /// Adapter to enable ServiceStack to use Castle Windsor IoC
    /// https://github.com/ServiceStackV3/ServiceStackV3/wiki/The-IoC-container
    /// 
    /// Castle Windsor
    /// http://docs.castleproject.org/Default.aspx?Page=MainPage&NS=Windsor&AspxAutoDetectCookieSupport=1
    /// </summary>
    public class WindsorContainerAdapter : IContainerAdapter, IDisposable, IRelease
    {
        private readonly IWindsorContainer _container;
        public IWindsorContainer Container { get { return this._container; } }

        public WindsorContainerAdapter()
        {
            _container = new WindsorContainer();
            //addint suport for collections
            //http://stw.castleproject.org/Default.aspx?Page=Resolvers&NS=Windsor&AspxAutoDetectCookieSupport=1
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(this._container.Kernel));
            this._container.Install(
                FromAssembly.InDirectory(new ApplicationAssemblyFilter())
            );
        }

        public T TryResolve<T>()
        {
            if (_container.Kernel.HasComponent(typeof(T)))
            {
                return (T)_container.Resolve(typeof(T));
            }

            return default(T);
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public void Dispose()
        {
            _container.Dispose();
        }

        public void Release(object instance)
        {
            _container.Release(instance);
        }
    }
}