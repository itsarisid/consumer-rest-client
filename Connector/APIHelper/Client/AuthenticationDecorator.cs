using Connector.APIHelper.Interface;
using RestSharp;
using RestSharp.Authenticators;

namespace Connector.APIHelper.Client
{
    public class AuthenticationDecorator : IClient
    {
        private readonly IClient _client;
        private readonly AuthenticatorBase _authenticatorBase;

        public AuthenticationDecorator(IClient client, AuthenticatorBase authenticator) // Default Client
        {
            _client = client;
            _authenticatorBase = authenticator;
        }
        public void Dispose()
        {
            _client.Dispose();
        }

        [Obsolete]
        public RestClient GetClient()
        {
            //1. Invoke _client.GetClient() API

            var newClient = _client.GetClient();

            //2. Add the auth configuration
            //newClient.Authenticator = _authenticatorBase;
            //3. return the new client
            return newClient; // Plain RestClient + Auth Config 
            //  Rest Client + Tracer + Auth Config
        }
    }
}
