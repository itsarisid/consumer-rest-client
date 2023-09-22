using Connector.APIHelper.Interface;

namespace Connector.APIHelper
{
    public class RestApiExecutor
    {
        private ICommand Command;

        /// <summary>Sets the command.</summary>
        /// <param name="_command">The command.</param>
        public void SetCommand(ICommand _command)
        {
            Command = _command;
        }

        /// <summary>Executes the request.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public IResponse ExecuteRequest() => Command.ExecuteRequest();

        /// <summary>Executes the request.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///   <br />
        /// </returns>
        public IResponse<T> ExecuteRequest<T>() => Command.ExecuteRequest<T>();

        /// <summary>Downloads the data.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public byte[] DownloadData() => Command.DownloadData();

        /// <summary>Downloads the data asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public Task<byte[]> DownloadDataAsync() => Command.DownloadDataAsync();
    }
}
