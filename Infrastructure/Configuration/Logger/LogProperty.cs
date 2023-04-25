using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Logger
{
    public class LogProperty
    {
        public string Property { get; private set; }
        public object Value { get; private set; }

        public LogProperty(string property, object value)
        {
            Property = property;

            Value = CreateLogObject(value);
        }

        private string CreateLogObject(object obj)
        {
            if (obj == null) return null;

            var type = obj.GetType();

            if (type.IsPrimitive || type == typeof(decimal) || type == typeof(string))
            {
                return obj.ToString();
            }

            return JsonConvert.SerializeObject(obj);
        }

        public static LogProperty CreateLogProperty(string name, object obj)
            => new LogProperty(name, obj);
    }
}
