using Connector.APIHelper.Interface;
using RestSharp;

namespace Connector.APIHelper.Command
{
    public class DownloadRequestCommand : ICommand
    {
        private readonly AbstractRequest _abstractRequest;
        private readonly IClient _client;

        /// <summary>Initializes a new instance of the <see cref="DownloadRequestCommand" /> class.</summary>
        /// <param name="abstractRequest">The abstract request.</param>
        /// <param name="client">The client.</param>
        public DownloadRequestCommand(AbstractRequest abstractRequest, IClient client)
        {
            _abstractRequest = abstractRequest;
            _client = client;
        }

        /// <summary>Downloads the data.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public byte[] DownloadData()
        {
            // Get the client
            var client = _client.GetClient();
            // Build the request
            var request = _abstractRequest.Build();
            // call the download api on the client
            var data = client.DownloadData(request);
            return data;
        }

        /// <summary>Downloads the data asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<byte[]> DownloadDataAsync()
        {
            // Get the client
            var client = _client.GetClient();
            // Build the request
            var request = _abstractRequest.Build();
            // call the download API on the client
            return client.DownloadDataAsync(request);
        }

        /// <summary>Executes the request.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.NotImplementedException">Use Request Command for executing the request</exception>
        public IResponse ExecuteRequest()
        {
            throw new NotImplementedException("Use Request Command for executing the request");
        }

        /// <summary>Executes the request.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.NotImplementedException">Use Request Command for executing the request</exception>
        public IResponse<T> ExecuteRequest<T>()
        {
            throw new NotImplementedException("Use Request Command for executing the request"); 
        }
    }
}
