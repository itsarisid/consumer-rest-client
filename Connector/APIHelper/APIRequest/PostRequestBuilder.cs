using RestSharp;

namespace Connector.APIHelper.APIRequest
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class PostRequestBuilder : AbstractRequest
    {
        /// <summary>The rest request</summary>
        private readonly RestRequest _restRequest;

        /// <summary>Initializes a new instance of the <see cref="PostRequestBuilder" /> class.</summary>
        public PostRequestBuilder()
        {
            _restRequest = new RestRequest()
            {
                Method = Method.Post
            };
        }

        /// <summary>Builds this instance.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        public override RestRequest Build() => _restRequest;

        //URL

        /// <summary>Withes the URL.</summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public PostRequestBuilder WithUrl(string url)
        {
            WithUrl(url, _restRequest);
            return this;
        }

        // Headers
        /// <summary>Withes the headers.</summary>
        /// <param name="headers">The headers.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public PostRequestBuilder WithHeaders(Dictionary<string, string> headers)
        {
            WithHeaders(headers, _restRequest);
            return this;
        }


        /// <summary>Withes the body.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body">The body.</param>
        /// <param name="bodyType">Type of the body.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public PostRequestBuilder WithBody<T>(T body, RequestBodyType bodyType, ContentType? contentType = default) where T : class
        {
            switch (bodyType)
            {
                case RequestBodyType.STRING:
                    _ = _restRequest.AddStringBody(body.ToString(), contentType);
                    break;
                case RequestBodyType.JSON:
                    _restRequest.AddJsonBody<T>(body);
                    break;
                case RequestBodyType.XML:
                    _restRequest.AddXmlBody<T>(body);
                    break;
            }
            return this;
        }

        /// <summary>Withes the query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public PostRequestBuilder WithQueryParameters(Dictionary<string, string> parameters)
        {
            WithQueryParameters(parameters, _restRequest);
            return this;
        }


        /// <summary>Withes the file upload.</summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="content">The content.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public PostRequestBuilder WithFileUpload(string paramName, byte[] content, string fileName)
        {
            _restRequest.AddFile(paramName, content, fileName, "multipart/form-data");
            return this;
        }

        /// <summary>Withes the query parameters.</summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="restRequest">The rest request.</param>
        protected override void WithQueryParameters(Dictionary<string, string> parameters, RestRequest restRequest)
        {
            foreach (string key in parameters.Keys)
            {
                restRequest.AddQueryParameter(key, parameters[key]);
            }
        }

    }
}
