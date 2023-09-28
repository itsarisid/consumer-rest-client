using RestSharp;
using Connector.APIHelper.APIResponse;
using Connector.APIHelper.Interface;

namespace Connector.APIHelper.Command
{
    public class RequestCommand(AbstractRequest _abstractRequest, IClient _client) : ICommand
    {
        /// <summary>Downloads the data.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="NotImplementedException">Use the Download Command for File Download</exception>
        public byte[] DownloadData()
        {
            throw new NotImplementedException("Use the Download Command for File Download");
        }

        /// <summary>Downloads the data asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="NotImplementedException">Use the Download Command for File Download</exception>
        public Task<byte[]> DownloadDataAsync()
        {
            throw new NotImplementedException("Use the Download Command for File Download");
        }

        /// <summary>
        /// Executes the request.
        /// </summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IResponse ExecuteRequest()
        {
            var client = _client.GetClient();
            var request = _abstractRequest.Build();
            var response = client.Execute(request);
            return new Response(response);
        }

        /// <summary>Executes the request.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///   <br />
        /// </returns>
        public IResponse<T> ExecuteRequest<T>()
        {
            var client = _client.GetClient();
            var request = _abstractRequest.Build();
            var response = client.Execute<T>(request);
            return new Response<T>(response);
        }
    }
}
