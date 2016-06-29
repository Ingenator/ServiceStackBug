using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example.DTO
{
    public class DataProperty
    {
        protected string base64Value = string.Empty;
        public string Value { get { return this.base64Value; } private set { this.base64Value = value; } }

        public DataProperty Set(byte[] data)
        {
            this.base64Value = Convert.ToBase64String(data);
            return this;
        }

        public byte[] Get()
        {
            return Convert.FromBase64String(base64Value);
        }

        public static implicit operator DataProperty(byte[] data)
        {
            return new DataProperty().Set(data);
        }

        public static implicit operator byte[] (DataProperty rsaProperty)
        {
            if (rsaProperty == null)
                return null;
            return rsaProperty.Get();
        }
    }

    public class DataProperty<T> : DataProperty
    {
        public new DataProperty<T> Set(byte[] data)
        {
            base.Set(data);
            return this;
        }

        public static implicit operator DataProperty<T>(byte[] data)
        {
            return new DataProperty<T>().Set(data);
        }

        public static implicit operator byte[] (DataProperty<T> rsaPropery)
        {
            if (rsaPropery == null)
                return null;
            return rsaPropery.Get();
        }
    }
}