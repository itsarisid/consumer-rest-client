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


var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

var logger = new Logger(configuration);

logger.InitializeLogger();

//Exception handle.
AppDomain.CurrentDomain.UnhandledException += Utility.UnhandledExceptionTrapper;

var connector = new AppConnector(appSettings);

await connector.RunAsync();

// Application code which might rely on the config could start here.
await host.RunAsync();