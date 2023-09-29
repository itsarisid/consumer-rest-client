using RestSharp;

namespace Connector.APIHelper
{
    public abstract class AbstractRequest
    {
        /// <summary>Builds this instance.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public abstract RestRequest Build();

        // For URL

        /// <summary>Withes the URL.</summary>
        /// <param name="url">The URL.</param>
        /// <param name="restRequest">The rest request.</param>
        protected virtual void WithUrl(string url, RestRequest restRequest)
        {
            restRequest.Resource = url;
        }

        /// <summary>Withes the headers.</summary>
        /// <param name="header">The header.</param>
        /// <param name="restRequest">The rest request.</param>
        protected virtual void WithHeaders(Dictionary<string, string> header, RestRequest restRequest)
        {
            foreach (string key in header.Keys)
            {
                restRequest.AddOrUpdateHeader(key, header[key]);
            }
        }

        //QueryParameter

        /// <summary>Withes the query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="restRequest">The rest request.</param>
        protected virtual void WithQueryParameters(Dictionary<string, string> parameters, RestRequest restRequest)
        {
            foreach (string key in parameters.Keys)
            {
                restRequest.AddParameter(key, parameters[key]);
            }
        }

        /// <summary>Withes the update query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="restRequest">The rest request.</param>
        protected virtual void WithUpdateQueryParameters(Dictionary<string, string> parameters, RestRequest restRequest)
        {
            foreach (string key in parameters.Keys)
            {
                restRequest.AddOrUpdateParameter(key, parameters[key]);
            }
        }
    }
}
