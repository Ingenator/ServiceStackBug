using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Windsor
{
    public class ApplicationAssemblyFilter : AssemblyFilter
    {
        // The "ApplicationAssemblyFilter" is a custom class that just helps to 
        // automate registration to assemblies which match a particular pattern 
        // in the app path
        public ApplicationAssemblyFilter()
            //: base(AppDomain.CurrentDomain.BaseDirectory, Assembly.GetExecutingAssembly().GetName().Name + ".*.dll") { }
            : base(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin"), "*.dll") { }

        public ApplicationAssemblyFilter(string customPath) : base(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, customPath), "*.dll") { }
    }
}