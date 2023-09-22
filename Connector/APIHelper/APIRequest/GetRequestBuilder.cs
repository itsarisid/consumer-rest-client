using RestSharp;

namespace Connector.APIHelper.APIRequest
{
    public class GetRequestBuilder : AbstractRequest
    {
        /// <summary>The rest request</summary>
        private readonly RestRequest _restRequest;

        /// <summary>Initializes a new instance of the <see cref="GetRequestBuilder" /> class.</summary>
        public GetRequestBuilder()
        {
            _restRequest = new RestRequest()
            {
                Method = Method.Get
            };
        }

        /// <summary>Builds this instance.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public override RestRequest Build() => _restRequest;


        /// <summary>Withes the URL.</summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public GetRequestBuilder WithUrl(string url)
        {
            WithUrl(url, _restRequest);
            return this;
        }

        /// <summary>Withes the headers.</summary>
        /// <param name="headers">The headers.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public GetRequestBuilder WithHeaders(Dictionary<string, string> headers)
        {
            WithHeaders(headers, _restRequest);
            return this;
        }

        //QueryParameter
        /// <summary>Withes the query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public GetRequestBuilder WithQueryParameters(Dictionary<string, string> parameters)
        {
            WithQueryParameters(parameters, _restRequest);
            return this;
        }

    }
}
