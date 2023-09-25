using Serilog.Events;
using Serilog;
using Serilog.Formatting.Json;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Serilog.Formatting.Compact;

namespace Connector
{
    public class Logger
    {
        private IConfigurationRoot _configuration;
        public Logger(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public void InitializeLogger()
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                            .MinimumLevel.Override("System", LogEventLevel.Error)
                            .Enrich.FromLogContext()
                            .WriteTo.Console()
                            .ReadFrom.Configuration(_configuration)
                            //.WriteTo.File(new CompactJsonFormatter(), "log.txt")
                            .CreateLogger();
        }
    }
}
