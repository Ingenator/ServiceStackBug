using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.Services.InternalService
{
    public class ExampleMethod : IExample
    {
        public string GetDataExampleMethod()
        {
            //This is where the data gets populated but for the sake of the example it just return a simple string
            return "13";
        }
    }
}