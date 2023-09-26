// Ignore Spelling: Api
using RestSharp;

namespace Connector.APIHelper.APIRequest
{
    public class DeleteRequestBuilder : AbstractRequest
    {
        /// <summary>The rest request</summary>
        private readonly RestRequest _restRequest;

        /// <summary>Initializes a new instance of the <see cref="DeleteRequestBuilder" /> class.</summary>
        public DeleteRequestBuilder()
        {
            _restRequest = new RestRequest()
            {
                Method = Method.Delete
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
        public DeleteRequestBuilder WithUrl(string url)
        {
            WithUrl(url, _restRequest);
            return this;
        }

        /// <summary>Withes the default headers.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public DeleteRequestBuilder WithDefaultHeaders()
        {
            WithHeaders(null, _restRequest);
            return this;
        }

        /// <summary>Withes the headers.</summary>
        /// <param name="header">The header.</param>
        /// <param name="restRequest">The rest request.</param>
        protected override void WithHeaders(Dictionary<string, string> header, RestRequest restRequest)
        {
            restRequest.AddOrUpdateHeader("Accept", "text/plain");
        }

        //QueryParameter
        /// <summary>Withes the query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public DeleteRequestBuilder WithQueryParameters(Dictionary<string, string> parameters)
        {
            WithQueryParameters(parameters, _restRequest);
            return this;
        }
    }
}
