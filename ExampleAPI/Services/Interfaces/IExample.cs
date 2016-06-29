using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Services.InternalService
{
    public interface IExample : IInternalService
    {
        string GetDataExampleMethod();
    }

}
