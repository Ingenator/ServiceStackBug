using NLog;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using Example.DTO;

namespace Example.Services
{
    public class ExampleService : ServiceBase, IPost<MyExampleService>
    {
        private static Logger log = LogManager.GetCurrentClassLogger();
        public object Post(MyExampleService request)
        {
            var sTheValue = Example.GetDataExampleMethod();
            var response = this.CreateResponse<MyExampleServiceResponse>();
            
            response.FistValueResponse = new DataProperty();
            response.FistValueResponse.Set(GetBytes(sTheValue));

            response.SecondValueReponse = new DataProperty<long>();
            response.SecondValueReponse.Set(GetBytes(sTheValue));

            response.ThirdValueResponse = new DataProperty<double>();
            response.ThirdValueResponse.Set(GetBytes(sTheValue));

            response.PlainValueResponse = long.Parse(sTheValue);
            /*This ones print something*/
            Debug.WriteLine("First : " + Convert.ToBase64String(response.FistValueResponse));
            Debug.WriteLine("Second : " + Convert.ToBase64String(response.SecondValueReponse));
            Debug.WriteLine("Third : " + Convert.ToBase64String(response.ThirdValueResponse));
            return response;
        }
        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

    }
}