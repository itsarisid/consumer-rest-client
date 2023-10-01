using Connector.APIHelper.Interface;
using RestSharp;
using System.Text;

namespace Connector.APIHelper.APIResponse
{
    /// <summary>Response</summary>
    public class Response : AbstractResponse
    {
        /// <summary>The rest response</summary>
        private readonly RestResponse _restResponse;

        /// <summary>Initializes a new instance of the <see cref="Response" /> class.</summary>
        /// <param name="restResponse">The rest response.</param>
        public Response(RestResponse restResponse) : base(restResponse)
        {
            _restResponse = restResponse;
        }

        /// <summary>Gets the response data.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public override string GetResponseData() => _restResponse.Content;

        /// <summary>Saves the response.</summary>
        /// <param name="path">The path.</param>
        public override void SaveInFile(string path)
        {
            File.AppendAllText(path, Environment.NewLine + _restResponse.Content);
        }
    }

    /// <summary>
    ///   <br />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> : AbstractResponse<T>
    {
        private readonly RestResponse<T> _restResponse;

        /// <summary>Initializes a new instance of the <see cref="Response{T}" /> class.</summary>
        /// <param name="restResponse">The rest response.</param>
        public Response(RestResponse<T> restResponse) : base(restResponse)
        {
            _restResponse = restResponse;
        }

        /// <summary>Gets the response data.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public override T GetResponseData() => _restResponse.Data;

        /// <summary>Saves the response.</summary>
        /// <param name="path">The path.</param>
        public override void SaveInFile(string path)
        {
            File.AppendAllText(path, Environment.NewLine + _restResponse.Content);
        }
    }
}
