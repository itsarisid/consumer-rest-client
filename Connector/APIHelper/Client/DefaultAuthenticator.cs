using RestSharp.Authenticators;
using RestSharp;
using Connector.Models;

namespace Connector.APIHelper.Client
{
    public class DefaultAuthenticator : AuthenticatorBase
    {
        readonly string _baseUrl;
        readonly string _clientId;
        readonly string _clientSecret;

        public DefaultAuthenticator(string baseUrl, string clientId, string clientSecret) : base("")
        {
            _baseUrl = baseUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            Token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            return new HeaderParameter(KnownHeaders.Authorization, Token);
        }

        async Task<string> GetToken()
        {
            var options = new RestClientOptions(_baseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret),
            };

            using var client = new RestClient(options);
            
            var request = new RestRequest("oauth2/token")
                .AddParameter("grant_type", "client_credentials");
            var response = await client.PostAsync<TokenResponse>(request);
            return $"{response!.TokenType} {response!.AccessToken}";
        }
    }
}
