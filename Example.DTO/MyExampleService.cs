using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.DTO
{
    [Route("/MyExampleService", "POST")]
    public class MyExampleService : IReturn<MyExampleServiceResponse>
    {
        public string Param { get; set; }
    }
}