using RestSharp;
using Connector.Models;
using Serilog;
using System.Runtime;

namespace Connector.APIHelper.APIRequest
{
    public class RequestBuilder(RequestModel _settings) 
    {
        /// <summary>Builds the request.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public AbstractRequest BuildRequest() => _settings.Method switch
        {
            Method.Get => GetRequest(),
            Method.Post => PostRequest(),
            Method.Delete => DeleteRequest(),
            Method.Put => PutRequest(),
            _ => throw new ArgumentException(message: "invalid method type", paramName: nameof(_settings.Method)),
        };

        /// <summary>Gets the request.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        private AbstractRequest GetRequest()
        {
            Log.Logger.Information(_settings.Uri);

            var request = new GetRequestBuilder()
                  .WithUrl(_settings.Uri)
                  .AddHeader(_settings.Headers)
                  .AddParameters(_settings.Parameters);

            return request;
        }

        /// <summary>Posts the request.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        private AbstractRequest PostRequest()
        {
            Log.Logger.Information(_settings.Uri);

            var headers = _settings.Headers.ToDictionary(v => v.Key, v => v.Value);
            var parameters = _settings.Parameters.ToDictionary(v => v.Key, v => v.Value);

            var request = new PostRequestBuilder()
                  .WithUrl(_settings.Uri)
                  .WithBody<string>(_settings.Body, _settings.RequestBodyType)
                  .WithHeaders(headers)
                  .WithQueryParameters(parameters);

            return request;
        }

        /// <summary>Puts the request.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        private AbstractRequest PutRequest()
        {
            throw new NotImplementedException();
        }

        /// <summary>Deletes the request.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        private AbstractRequest DeleteRequest()
        {
            throw new NotImplementedException();
        }
    }
}