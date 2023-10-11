using Connector.Entities;
using RestSharp;

namespace Connector.Models
{
    public class RequestModel
    {
        public Method Method { get; set; }
        public string Uri { get; set; }
        public Page Page { get; set; }
        public string NextUrl { get; set; }
        public string Body { get; set; }
        public RequestBodyType RequestBodyType { get; set; }
        public List<KeyValueParameter> Headers { get; set; }
        public List<KeyValueParameter> Parameters { get; set; }
    }

    public class RequestBody
    {
        public string Body { get; set; }
    }

    public class KeyValueParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class Page
    {
        public KeyValueParameter Size { get; set; }
        public int Total { get; set; }
        public KeyValueParameter Number { get; set; }
    }

    public class ValidateRequestParam
    {
        public ApiDetail ApiDetail { get; set; }
        public ApiRequest ApiRequest { get; set; }
        public List<Header> Headers { get; set; }
        public List<Entities.QueryParameter> QueryParameters { get; set; }
    }
}