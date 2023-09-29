using Connector.Models;
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

        /// <summary>Withes the update query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public GetRequestBuilder WithUpdateQueryParameters(Dictionary<string, string> parameters)
        {
            WithUpdateQueryParameters(parameters, _restRequest);
            return this;
        }

        /// <summary>Adds the parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public GetRequestBuilder AddParameters(List<KeyValueParameter> parameters)
        {
            if (parameters.AnyOrNotNull())
            {
                WithQueryParameters(parameters.ToDictionary(v => v.Key, v => v.Value));
            }
            return this;
        }

        /// <summary>Adds the or update parameter.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public GetRequestBuilder AddOrUpdateParameter(List<KeyValueParameter> parameters)
        {
            if (parameters.AnyOrNotNull())
            {
                WithUpdateQueryParameters(parameters.ToDictionary(v => v.Key, v => v.Value));
            }
            return this;
        }

        /// <summary>Adds the header.</summary>
        /// <param name="headers">The headers.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public GetRequestBuilder AddHeader(List<KeyValueParameter> headers)
        {
            if (headers.AnyOrNotNull())
            {
                WithHeaders(headers.ToDictionary(v => v.Key, v => v.Value));
            }
            return this;
        }
    }
}
