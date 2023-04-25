using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Infrastructure.Configuration.Logger
{
    public class IdentityServerLog : IIdentityServerLog
    {
        private readonly ILogger _logger;
        public IdentityServerLog(ILogger logger)
        {
            _logger = logger;
        }

        public void Error(string message, params LogProperty[] properties)
        {
            _logger
                .ForContext(new LogPropertyEnricher()
                    .AddRange(logProperties: properties))
                .Error(message);
        }

        public void Warning(string message, params LogProperty[] properties)
        {
            _logger
                .ForContext(new LogPropertyEnricher()
                    .AddRange(logProperties: properties))
                .Warning(message);
        }

        public void Debug(string message, params LogProperty[] properties)
        {
            _logger
                .ForContext(new LogPropertyEnricher()
                    .AddRange(logProperties: properties))
                .Debug(message);
        }

        public void Error(Exception exception, params LogProperty[] properties)
        {
            var msgs = string.Join(" ", properties.Select(x => $"[{x.Property}] {x.Value}"));

            _logger
                .ForContext(new LogPropertyEnricher()
                    .AddExceptionInformation(exception)
                    .AddRange(logProperties: properties))
                .Error($"[Message] {exception.Message} [Inner Exception] {exception.InnerException?.Message} [StackTrace] {exception.StackTrace} {msgs}");
        }
    }
}
