using RestSharp;

namespace Connector.APIHelper.APIRequest
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class PutRequestBuilder : AbstractRequest
    {
        private readonly RestRequest _restRequest;

        public PutRequestBuilder()
        {
            _restRequest = new RestRequest()
            {
                Method = Method.Put
            };
        }

        /// <summary>Builds this instance.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public override RestRequest Build() => _restRequest;

        //URL

        /// <summary>Withes the URL.</summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public PutRequestBuilder WithUrl(string url)
        {
            WithUrl(url, _restRequest);
            return this;
        }

        // Headers
        /// <summary>Withes the headers.</summary>
        /// <param name="headers">The headers.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public PutRequestBuilder WithHeaders(Dictionary<string, string> headers)
        {
            WithHeaders(headers, _restRequest);
            return this;
        }


        /// <summary>Withes the body.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body">The body.</param>
        /// <param name="bodyType">Type of the body.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public PutRequestBuilder WithBody<T>(T body, RequestBodyType bodyType, ContentType? contentType = default) where T : class
        {
            // String
            // Object 

            switch (bodyType)
            {
                case RequestBodyType.STRING:
                    _restRequest.AddStringBody(body.ToString(), contentType);
                    break;
                case RequestBodyType.JSON:
                    _restRequest.AddJsonBody<T>(body);
                    break;
                case RequestBodyType.XML:
                    _restRequest.AddXmlBody<T>(body);
                    break;
            }
            return this;
        }

        /// <summary>Withes the query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public PutRequestBuilder WithQueryParameters(Dictionary<string, string> parameters)
        {
            WithQueryParameters(parameters, _restRequest);
            return this;
        }


        /// <summary>Withes the query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="restRequest">The rest request.</param>
        protected override void WithQueryParameters(Dictionary<string, string> parameters, RestRequest restRequest)
        {
            foreach (string key in parameters.Keys)
            {
                restRequest.AddQueryParameter(key, parameters[key]);
            }
        }
    }
}
