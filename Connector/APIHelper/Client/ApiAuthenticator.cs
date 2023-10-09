// Ignore Spelling: Api
using Connector.APIHelper.APIRequest;
using Connector.APIHelper.Client;
using Connector.Models;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;

namespace Connector.Client
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class ApiAuthenticator(AuthenticationParameter? parameter)
    {
        /// <summary>Authenticates the specified authenticator type.</summary>
        /// <param name="authenticatorType">Type of the authenticator.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.NotImplementedException">Not Implemented custom Authenticator</exception>
        public IAuthenticator? Authenticate(AuthenticatorType authenticatorType) => authenticatorType switch
        {
            AuthenticatorType.None => null,
            AuthenticatorType.Basic => new HttpBasicAuthenticator(parameter.UserName, parameter.Password),
            AuthenticatorType.OAuth1 => OAuth1Authenticator.ForRequestToken(parameter.ConsumerKey, parameter.ConsumerSecret),
            AuthenticatorType.OAuth2 => new OAuth2AuthorizationRequestHeaderAuthenticator(parameter.Token, "Bearer"),
            AuthenticatorType.JWT => new JwtAuthenticator(parameter.Token),
            AuthenticatorType.Custom => new DefaultAuthenticator(parameter.URL, parameter.ConsumerKey, parameter.ConsumerSecret),
            _ => throw new ArgumentException(message: "invalid authenticator type", paramName: nameof(authenticatorType)),
        };
    }
}
