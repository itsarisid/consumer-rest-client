using System.Net;

namespace Connector.APIHelper.Interface
{
    public interface IRestApiResponse
    {
        /// <summary>Gets the HTTP status code.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        HttpStatusCode GetHttpStatusCode();

        /// <summary>Gets the exception.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        Exception GetException();

        /// <summary>Saves the response.</summary>
        /// <param name="path">The path.</param>
        void SaveInFile(string path);
    }
}
