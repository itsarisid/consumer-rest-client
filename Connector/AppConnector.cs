using Connector.APIHelper.APIRequest;
using Connector.APIHelper.Client;
using Connector.APIHelper.Command;
using Connector.APIHelper;
using RestSharp;
using System.Net;
using Connector.Client;
using Connector.Models;
using Connector.APIHelper.Interface;
using Serilog.Events;
using Serilog;

namespace Connector
{
    public class AppConnector
    {
        private AppSettings AppSettings { get; set; }
        public AppConnector(AppSettings? settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            AppSettings = settings;
        }

        /// <summary>Main program runner</summary>
        /// <exception cref="System.ArgumentNullException">BaseUrl</exception>
        /// <exception cref="System.Exception">Error with status code: {response.StatusCode}</exception>
        public async Task RunAsync()
        {
            

            if (string.IsNullOrEmpty(AppSettings?.BaseUrl)) throw new ArgumentNullException(nameof(AppSettings.BaseUrl));

            IClient _client = new DefaultClient(new RestClientOptions()
            {
                ThrowOnAnyError = true,
                BaseUrl = new Uri(AppSettings.BaseUrl),
                MaxTimeout = -1,
                Authenticator = new ApiAuthenticator(AppSettings.AuthenticationParameter).Authenticate(AppSettings.AuthenticatorType)
            });

            RestApiExecutor apiExecutor = new();

            // GET end point URL
            string getUrl = "/data/v1/user";
            AbstractRequest abstractRequest = new GetRequestBuilder()
                .WithUrl(getUrl)
                .WithHeaders(new Dictionary<string, string>()
            {
                { "Accept", "application/json"},
                { "Content-Type", "application/json" },
                { "app-id","650c72958b4bf3217aef1cc6" }
            });

            ICommand getCommand = new RequestCommand(abstractRequest, _client);

            apiExecutor.SetCommand(getCommand);

            var response = apiExecutor.ExecuteRequest();

            var statusCode = response.GetHttpStatusCode();

            if (statusCode != HttpStatusCode.OK)
                throw new Exception($"Error with status code: {statusCode}");
            if (statusCode == HttpStatusCode.OK)
            {
                Log.Logger.Information("Status OK");
                // Read bytes
                var path = string.IsNullOrEmpty(AppSettings?.OutputDirectory) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : AppSettings.OutputDirectory;
                File.WriteAllText(path + "\\output.json", response.GetResponseData());
            }

            _client.Dispose();
        }
    }
}
