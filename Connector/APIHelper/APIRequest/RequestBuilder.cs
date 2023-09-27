using RestSharp;
using Connector.Models;
using Serilog;

namespace Connector.APIHelper.APIRequest
{
    public class RequestBuilder(AppSettings _settings)
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
            var requestData = _settings.Requests.First();

            Log.Logger.Information(requestData.Uri);

            var request = new GetRequestBuilder()
                  .WithUrl(requestData.Uri)
                  .AddHeader(requestData.Headers)
                  .AddParameters(requestData.Parameters);

            return request;
        }

        /// <summary>Posts the request.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        private AbstractRequest PostRequest()
        {
            throw new NotImplementedException();
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