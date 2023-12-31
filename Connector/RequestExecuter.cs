﻿using Connector.APIHelper.Client;
using Connector.APIHelper.Interface;
using Connector.APIHelper;
using Connector.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connector.APIHelper.APIRequest;
using Connector.APIHelper.Command;
using Connector.Models;
using Serilog;
using System.Net;
using Connector.Services;
using Connector.Repositories;
using Newtonsoft.Json.Linq;
using Azure.Core;
using System.IO;
using Connector.Entities;

namespace Connector
{
    public class RequestExecuter
    {
        private readonly IService<ApiDetail> apiDetailService;
        private readonly IService<ApiRequest> apiRequestService;
        private readonly IService<Header> apiHeaderService;
        private readonly IService<Entities.QueryParameter> apiQueryService;

        private StringBuilder data;

        private AppSettings settings;

        public ValidateRequestParam validateRequest;


        public RequestExecuter()
        {
            apiDetailService = new Service<ApiDetail>(new Repository<ApiDetail>());
            apiRequestService = new Service<ApiRequest>(new Repository<ApiRequest>());
            apiHeaderService = new Service<Header>(new Repository<Header>());
            apiQueryService = new Service<Entities.QueryParameter>(new Repository<Entities.QueryParameter>());

            data = new StringBuilder();
        }

        /// <summary>Initializes this instance.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.NullReferenceException">apiDetails
        /// or
        /// request</exception>
        public RequestExecuter Initialize()
        {
            if (validateRequest == null)
            {
                var apiDetails = apiDetailService.FindBy(x => x.Name == "Klaviyo").FirstOrDefault();
                if (apiDetails == null)
                {
                    throw new NullReferenceException(nameof(apiDetails));
                }
                var request = apiRequestService.FindBy(x => x.ApiId == apiDetails.Id).FirstOrDefault();
                if (request == null)
                {
                    throw new NullReferenceException(nameof(request));
                }

                request.Headers = apiHeaderService.FindBy(x => x.ReqId == request.Id).ToList();
                request.QueryParameters = apiQueryService.FindBy(x => x.ReqId == request.Id).ToList();

                validateRequest = new ValidateRequestParam
                {
                    ApiDetail = apiDetails,
                    ApiRequest = request,
                };
            }
            return this;
        }


        /// <summary>Validates this instance.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.NullReferenceException">validateRequest
        /// or
        /// apiDetails
        /// or
        /// request</exception>
        public RequestExecuter Validate()
        {
            if (validateRequest == null)
            {
                throw new NullReferenceException(nameof(validateRequest));
            }
            var apiDetails = validateRequest.ApiDetail;
            if (apiDetails == null)
            {
                throw new NullReferenceException(nameof(apiDetails));
            }
            var request = validateRequest.ApiRequest;
            if (request == null)
            {
                throw new NullReferenceException(nameof(request));
            }

            var header = validateRequest.ApiRequest.Headers;
            var parameters = validateRequest.ApiRequest.QueryParameters;

            settings = new AppSettings
            {
                AppName = apiDetails.Name,
                AuthenticatorType = apiDetails.AuthType.ToEnum<AuthenticatorType>(AuthenticatorType.None),
                AuthenticationParameter = new AuthenticationParameter
                {
                    Token = apiDetails.Token,
                    ConsumerKey = apiDetails.ConsumerKey,
                    ConsumerSecret = apiDetails.ConsumerSecret,
                    OAuthToken = apiDetails.OauthToken,
                    OAuthTokenSecret = apiDetails.OauthTokenSecret,
                    UserName = apiDetails.UserName,
                    Password = apiDetails.Password,
                    APIKey = apiDetails.Apikey,
                    URL = "https://home.mozu.com/api/platform/applications/authtickets/oauth"
                },
                OutputDirectory = "D:\\consumer-rest-client\\Connector\\Output",
                Requests = new List<RequestModel>
                {
                    new RequestModel
                    {
                        Method = apiDetails.Method.ToEnum<Method>(Method.Get),
                        Uri = request.ResourceUrl ?? "",
                        Headers = Utility.ConvertToKeyValue<Header>(header),
                        Parameters = Utility.ConvertToKeyValue<Entities.QueryParameter>(parameters),
                    }
                },
                BaseUrl = "https://home.mozu.com/api/platform/applications/authtickets/oauth"// request.BaseUrl,

            };


            return this;
        }

        /// <summary>Runs this instance.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentNullException">BaseUrl</exception>
        public string Run()
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
                    // WithPagination(apiExecutor, _client, request);
                }
                else
                {
                    ExecuteRequest(apiExecutor, _client, request);
                }
            }

            _client.Dispose();

            return data.ToString();
        }

        /// <summary>Execute the request.</summary>
        /// <param name="apiExecutor">The API executor.</param>
        /// <param name="client">The client.</param>
        /// <param name="requestModel">The request model.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        private RequestExecuter ExecuteRequest(RestApiExecutor apiExecutor, IClient client, RequestModel requestModel)
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

                //ReconnectAndContinue();
            }

            if (statusCode == HttpStatusCode.OK)
            {
                Log.Logger.Information("Status OK");

                string _data = response.GetResponseData();
                data.AppendLine(_data);


                var path = string.IsNullOrEmpty(settings?.OutputDirectory) ? Environment.GetFolderPath(Environment.SpecialFolder.Desktop) : settings.OutputDirectory;

                path = $"{path}\\{requestModel.Uri.GetEndpointName()}.json";

                //Save file in JSON
                response.SaveInFile(path);
            }
            return this;
        }
    }
}
