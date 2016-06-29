using ServiceStack;
using Example.DTO;
using Example.Services.InternalService;

namespace Example.Services
{
    public abstract class ServiceBase : Service
    {
        public IExample Example { get; set; }
        protected T CreateResponse<T>() where T : new()
        {
            T message = new T();
            return message;
        }
    }
}