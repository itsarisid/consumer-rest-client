using Connector.APIHelper.Interface;
using RestSharp;

namespace Connector.APIHelper.Client
{
    public class DefaultClient : RestClient, IClient
    {
        private RestClient _client;
        private readonly RestClientOptions _options;

        /// <summary>Initializes a new instance of the <see cref="DefaultClient" /> class.</summary>
        public DefaultClient()
        {
            _options = new RestClientOptions();
        }
        /// <summary>Initializes a new instance of the <see cref="DefaultClient" /> class.</summary>
        /// <param name="options">The options.</param>
        public DefaultClient(RestClientOptions options)
        {
            _options = options;
        }

        /// <summary>Releases unmanaged and - optionally - managed resources.</summary>
        public new void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <summary>Gets the client.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public RestClient GetClient()
        {
            _options.ThrowOnDeserializationError = true;
            _options.ThrowOnAnyError = true;

            if (_client == null)
                _client = new RestClient(_options);
            return _client;
        }
    }
}
