using Connector;
using Connector.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestSharp;
using System.Reflection;

using IHost host = Host.CreateApplicationBuilder(args).Build();

IServiceCollection services = new ServiceCollection();

// Configuration abstraction.
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

var appSettings = config.GetSection("Setting").Get<AppSettings>();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
services.AddLogging(options =>
{
    options.AddDebug();
    options.AddConsole();
}
);

Logger logger = new(configuration);

logger.InitializeLogger();

//Exception handle.
AppDomain.CurrentDomain.UnhandledException += Utility.UnhandledExceptionTrapper;

AppConnector connector = new(appSettings);

connector.Run();

// Application code which might rely on the config could start here.
await host.RunAsync();