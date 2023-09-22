namespace Connector.APIHelper.Interface
{
    public interface ICommand
    {
        /// <summary>Executes the request.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        /// 
        IResponse ExecuteRequest(); // for response in string format

        /// <summary>Executes the request.</summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///   <br />
        /// </returns>
        IResponse<T> ExecuteRequest<T>(); // for the deserialize object from response

        /// <summary>Downloads the data.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        byte[] DownloadData();

        /// <summary>Downloads the data asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<byte[]> DownloadDataAsync();
    }
}
