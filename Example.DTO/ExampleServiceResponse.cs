using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.DTO
{
    public class MyExampleServiceResponse : ResponseBase
    {
        public DataProperty FistValueResponse { get; set; }

        public DataProperty<long> SecondValueReponse { get; set; }

        public DataProperty<double> ThirdValueResponse { get; set; }

        public long PlainValueResponse { get; set; }
    }
}