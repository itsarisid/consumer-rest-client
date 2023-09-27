using Connector.APIHelper.Interface;
using RestSharp;

namespace Connector.APIHelper.Client
{
    public class BasicAuthDecorator(IClient _client) : IClient
    {
        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        public void Dispose()
        {
            _client.Dispose();
        }

        /// <summary>Gets the client.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public RestClient GetClient()
        {
            //1. Invoke _client.GetClient() API

            var newClient = _client.GetClient(); // Plain RestClient // Rest Client + Tracer

            //2. Add the auth configuration
            //newClient.Authenticator = new HttpBasicAuthenticator("admin", "welcome");
            
            //3. return the new client
            return newClient; 
        }
    }
}
