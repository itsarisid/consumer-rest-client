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
        private static AbstractRequest GetRequest()
        {
            Log.Logger.Information("/api/commerce/shipments");
            // GET end point URL
            string getUrl = "/api/commerce/shipments?pageSize=500&filter=auditInfo.updateDate%3Dge%3D2023-08-08T05%3A00%3A00.000Z%20and%20auditInfo.updateDate%3Dle%3D2023-09-18T04%3A59%3A59.999Z%20and%20shipmentStatus%3Deq%3DCANCELED";

            return new GetRequestBuilder()
                  .WithUrl(getUrl);
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