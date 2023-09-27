using Connector.APIHelper.APIRequest;
using Connector.APIHelper.Client;
using Connector.APIHelper.Command;
using Connector.APIHelper;
using RestSharp;
using System.Net;
using Connector.Client;
using Connector.Models;
using Connector.APIHelper.Interface;
using Serilog;

namespace Connector
{
    public class AppConnector(AppSettings? settings)
    {
        /// <summary>Main program runner</summary>
        /// <exception cref="System.ArgumentNullException">BaseUrl</exception>
        /// <exception cref="System.Exception">Error with status code: {response.StatusCode}</exception>
        public async Task RunAsync()
        {
            if (string.IsNullOrEmpty(settings?.BaseUrl)) throw new ArgumentNullException(nameof(settings.BaseUrl));

            IClient _client = new DefaultClient(new RestClientOptions()
            {
                ThrowOnAnyError = true,
                BaseUrl = new Uri(settings.BaseUrl),
                MaxTimeout = -1,
                Authenticator = new ApiAuthenticator(settings.AuthenticationParameter).Authenticate(settings.AuthenticatorType)
            });

            RestApiExecutor apiExecutor = new();

            foreach (var item in settings.Requests)
            {
                // Create request
                RequestBuilder requestBuilder = new(item);

                var request = requestBuilder.BuildRequest();

                ICommand getCommand = new RequestCommand(request, _client);

                apiExecutor.SetCommand(getCommand);

                var response = apiExecutor.ExecuteRequest();

                var statusCode = response.GetHttpStatusCode();

                if (statusCode != HttpStatusCode.OK)
                    throw new Exception($"Error with status code: {statusCode}");

                if (statusCode == HttpStatusCode.OK)
                {
                    Log.Logger.Information("Status OK");

                    // Read bytes
                    var path = string.IsNullOrEmpty(settings?.OutputDirectory) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : settings.OutputDirectory;

                    File.AppendAllText(path + "\\output.json", Environment.NewLine + response.GetResponseData());
                }
            }


            _client.Dispose();
        }
    }
}
