using Connector;
using Connector.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestSharp;

using IHost host = Host.CreateApplicationBuilder(args).Build();

// Configuration abstraction.
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

var appSettings = config.GetSection("Setting").Get<AppSettings>();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

Logger logger = new(configuration);

logger.InitializeLogger();

//Exception handle.
AppDomain.CurrentDomain.UnhandledException += Utility.UnhandledExceptionTrapper;

AppConnector connector = new(appSettings);

await connector.RunAsync();

// Application code which might rely on the config could start here.
await host.RunAsync();