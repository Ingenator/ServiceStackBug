using ServiceStack;
using ServiceStack.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Example.Services;
using Example.Windsor;

namespace Example
{
    public class Global : System.Web.HttpApplication
    {
        public class ExampleAppHost : AppHostBase
        {
            public ExampleAppHost() : base("Example Web Services", typeof(ExampleService).Assembly)
            {
                this.Plugins.Add(new ValidationFeature());
            }
            public override void Configure(Funq.Container container)
            {
                //register adapter for Windsor
                this.Container.Adapter = new WindsorContainerAdapter();
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {           
            new ExampleAppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}