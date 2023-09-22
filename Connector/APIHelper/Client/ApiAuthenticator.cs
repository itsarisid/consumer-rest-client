// Ignore Spelling: Api
using Connector.Models;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

namespace Connector.Client
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class ApiAuthenticator
    {
        private string token;
        private string consumerKey;
        private string consumerSecret;
        private string username;
        private string password;


        /// <summary>Initializes a new instance of the <see cref="ApiAuthenticator" /> class.</summary>
        /// <param name="parameter">The parameter.</param>
        public ApiAuthenticator(AuthenticationParameter? parameter)
        {
            if (parameter != null)
            {
                token = parameter.Token ?? "";
                consumerKey = parameter.ConsumerKey ?? "";
                consumerSecret = parameter.ConsumerSecret ?? "";
                username = parameter.UserName ?? "";
                password = parameter.Password ?? "";
            }
        }

        /// <summary>Authenticates the specified authenticator type.</summary>
        /// <param name="authenticatorType">Type of the authenticator.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.NotImplementedException">Not Implemented custom Authenticator</exception>
        public IAuthenticator? Authenticate(AuthenticatorType authenticatorType) => authenticatorType switch
        {
            AuthenticatorType.None => null,
            AuthenticatorType.Basic => new HttpBasicAuthenticator(username, password),
            AuthenticatorType.OAuth1 => OAuth1Authenticator.ForRequestToken(consumerKey, consumerSecret),
            AuthenticatorType.OAuth2 => new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer"),
            AuthenticatorType.JWT => new JwtAuthenticator(token),
            AuthenticatorType.Custom => throw new NotImplementedException("Not Implemented custom Authenticator"),
            _ => throw new ArgumentException(message: "invalid authenticator type", paramName: nameof(authenticatorType)),
        };

    }
}
