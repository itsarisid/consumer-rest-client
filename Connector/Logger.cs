using Serilog.Events;
using Serilog;
using Microsoft.Extensions.Configuration;

namespace Connector
{
    public class Logger(IConfigurationRoot _configuration)
    {
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
