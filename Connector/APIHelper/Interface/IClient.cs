using RestSharp;
namespace Connector.APIHelper.Interface
{
    public interface IClient : IDisposable
    {
        /// <summary>Gets the client.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        RestClient GetClient();
    }
}
