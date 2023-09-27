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

        /// <summary>Initializes a new instance of the <see cref="DefaultAuthenticator" /> class.</summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="clientSecret">The client secret.</param>
        public DefaultAuthenticator(string baseUrl, string clientId, string clientSecret) : base("")
        {
            _baseUrl = baseUrl;
            _clientId = clientId;
            _clientSecret = clientSecret;
        }

        /// <summary>Gets the authentication parameter.</summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            Token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            return new HeaderParameter(KnownHeaders.Authorization, Token);
        }

        /// <summary>Gets the token.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
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
