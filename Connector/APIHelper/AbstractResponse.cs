using Connector.APIHelper.Interface;
using RestSharp;
using System.Net;
namespace Connector.APIHelper
{
    public abstract class AbstractResponse(RestResponse _restResponse) : IResponse
    {
        /// <summary>Gets the exception.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public Exception GetException() => _restResponse.ErrorException;

        /// <summary>Gets the HTTP status code.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public HttpStatusCode GetHttpStatusCode() => _restResponse.StatusCode;

        /// <summary>Gets the response data.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public abstract string GetResponseData();

        /// <summary>Saves the response.</summary>
        /// <param name="path">The path.</param>
        public abstract void SaveInFile(string path);
    }

    /// <summary>
    ///   <br />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractResponse<T> : IResponse<T>
    {

        /// <summary>The rest response</summary>
        private readonly RestResponse<T> _restResponse;

        /// <summary>Initializes a new instance of the <see cref="AbstractResponse{T}" /> class.</summary>
        /// <param name="restResponse">The rest response.</param>
        public AbstractResponse(RestResponse<T> restResponse)
        {
            _restResponse = restResponse;
        }

        /// <summary>Gets the exception.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public Exception GetException() => _restResponse.ErrorException;

        /// <summary>Gets the HTTP status code.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public HttpStatusCode GetHttpStatusCode() => _restResponse.StatusCode;

        /// <summary>Gets the response data.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public abstract T GetResponseData();

        /// <summary>Saves the response.</summary>
        /// <param name="path">The path.</param>
        public abstract void SaveInFile(string path);
    }
}
