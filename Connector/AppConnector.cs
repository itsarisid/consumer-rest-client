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
using System.Collections.Generic;

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
                if (request.Page != null)
                {
                    WithPagination(apiExecutor, _client, request);
                }
                else
                {
                    ProcessRequest(apiExecutor, _client, request);
                }
            }

            _client.Dispose();
        }

        /// <summary>
        /// Runs the pagination.
        /// </summary>
        /// <param name="executor">The executor.</param>
        /// <param name="client">The client.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">Page</exception>
        public void WithPagination(RestApiExecutor executor, IClient client, RequestModel request)
        {
            var page = request.Page ?? throw new ArgumentNullException(nameof(request.Page));

            var parameters = new List<KeyValueParameter>
            {
                page.Size,
                page.Number
            };

            for (int i = 1; i <= page.Total; i++)
            {
                //TODO: Call with paging until reach last page.

                //Update page number.
                var newList = parameters.Where(w => w.Key != page.Number.Key).ToList();
                newList.Add(new KeyValueParameter
                {
                    Key = page.Number.Key,
                    Value = i.ToString()
                });

                request.Parameters = newList;

                ProcessRequest(executor, client, request);
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
        private AppConnector ProcessRequest(RestApiExecutor apiExecutor, IClient client, RequestModel requestModel)
        {
            RequestBuilder requestBuilder = new(requestModel);

            // Create request
            var request = requestBuilder.BuildRequest();

            ICommand getCommand = new RequestCommand(request, client);

            apiExecutor.SetCommand(getCommand);

            var response = apiExecutor.ExecuteRequest();

            var statusCode = response.GetHttpStatusCode();

            if (statusCode != HttpStatusCode.OK)
            {
                //throw new Exception($"Error with status code: {statusCode}");

                Log.Logger.Error($"Error with status code: {statusCode}");

                ReconnectAndContinue();
            }

            if (statusCode == HttpStatusCode.OK)
            {
                Log.Logger.Information("Status OK");
                var path = string.IsNullOrEmpty(settings?.OutputDirectory) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : settings.OutputDirectory;

                path = $"{path}\\{requestModel.Uri.GetEndpointName()}.json";

                //Save file in JSON
                response.SaveInFile(path);
            }
            return this;
        }


        /// <summary>Reconnects the and continue.</summary>
        private void ReconnectAndContinue()
        {
            //TODO: Save state for future resume in case for failure
        }
    }
}
