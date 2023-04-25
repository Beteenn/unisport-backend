using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration.Logger
{
    internal class LogPropertyEnricher : ILogEventEnricher
    {
        private readonly Dictionary<string, Tuple<object, bool>> _properties;

        public LogPropertyEnricher()
        {
            _properties = new Dictionary<string, Tuple<object, bool>>(StringComparer.OrdinalIgnoreCase);
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            foreach (KeyValuePair<string, Tuple<object, bool>> prop in _properties)
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(prop.Key, prop.Value.Item1, prop.Value.Item2));
            }
        }

        public LogPropertyEnricher AddExceptionInformation(Exception exception, bool destructureObject = false)
        {
            if (exception != null)
            {
                _properties.Add("Source", Tuple.Create((object)exception.Source, destructureObject));
                _properties.Add("TargetSite", Tuple.Create((object)exception.TargetSite.Name, destructureObject));
            }

            return this;
        }

        public LogPropertyEnricher Add(LogProperty logProperty, bool destructureObject = false)
        {
            if (string.IsNullOrEmpty(logProperty.Property))
                throw new ArgumentNullException(nameof(logProperty.Property));

            if (!_properties.ContainsKey(logProperty.Property))
                _properties.Add(logProperty.Property, Tuple.Create(logProperty.Value, destructureObject));

            return this;
        }

        public LogPropertyEnricher AddRange(bool destructureObject = false, params LogProperty[] logProperties)
        {
            foreach (var item in logProperties)
            {
                Add(item, destructureObject);
            }

            return this;
        }
    }
}
