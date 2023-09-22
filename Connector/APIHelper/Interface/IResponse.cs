namespace Connector.APIHelper.Interface
{
    public interface IResponse : IRestApiResponse
    {
        /// <summary>Gets the response data.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        string GetResponseData();
    }

    /// <summary>
    ///   <br />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResponse<T> : IRestApiResponse
    {
        T GetResponseData();
    }
}
