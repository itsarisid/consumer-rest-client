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
using System.Collections.Concurrent;
using Connector.APIHelper.APIResponse;

namespace Connector
{
    public class AppConnector(AppSettings? settings)
    {
        /// <summary>Main program runner</summary>
        /// <exception cref="System.ArgumentNullException">BaseUrl</exception>
        /// <exception cref="System.Exception">Error with status code: {response.StatusCode}</exception>
        public void Run()
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

            foreach (var request in settings.Requests)
            {
                ProcessRequest(apiExecutor, _client, request);
            }

            _client.Dispose();
        }

        /// <summary>Runs the pagination.</summary>
        /// <param name="request">The request.</param>
        /// <exception cref="System.ArgumentNullException">Page</exception>
        public void RunPagination(RequestModel request)
        {
            var page = request.Page;
            if (page is null) throw new ArgumentNullException(nameof(request.Page));

            for (int i = 0; i < page.Total; i++)
            {
                //TODO: Call with paging until reach last page.

            }
        }

        /// <summary>Runs the asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">BaseUrl</exception>
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

            ConcurrentBag<string> response = new();

            //Note: Call API 
            await Parallel.ForEachAsync(settings.Requests, async (request, cancellationToken) =>
            {
                ProcessRequest(apiExecutor, _client, request);
            });
        }

        /// <summary>Processes the request.</summary>
        /// <param name="apiExecutor">The API executor.</param>
        /// <param name="client">The client.</param>
        /// <param name="requestModel">The request model.</param>
        /// <exception cref="System.Exception">Error with status code: {statusCode}</exception>
        private void ProcessRequest(RestApiExecutor apiExecutor, IClient client, RequestModel requestModel)
        {
            // Create request
            RequestBuilder requestBuilder = new(requestModel);

            var request = requestBuilder.BuildRequest();

            ICommand getCommand = new RequestCommand(request, client);

            apiExecutor.SetCommand(getCommand);

            var response = apiExecutor.ExecuteRequest();

            var statusCode = response.GetHttpStatusCode();

            if (statusCode != HttpStatusCode.OK)
                throw new Exception($"Error with status code: {statusCode}");

            if (statusCode == HttpStatusCode.OK)
            {
                Log.Logger.Information("Status OK");
                var path = string.IsNullOrEmpty(settings?.OutputDirectory) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : settings.OutputDirectory;

                path = $"{path}\\{requestModel.Uri.GetEndpointName()}.json";

                response.SaveResponse(path);
            }
        }
    }
}
