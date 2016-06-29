using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.DTO
{
    public abstract class ResponseBase
    {
        public ResponseStatus ResponseStatus { get; set; }
    }

    public abstract class ResponseBase<T> : ResponseBase where T : new()
    {
        public T Data { get; set; }

        public ResponseBase() : base()
        {
            this.Data = new T();
        }
    }
}