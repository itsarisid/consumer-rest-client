using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Connector.Models
{
    public class RequestModel
    {
        public Method Method { get; set; }
        public string Uri { get; set; }
        public Page Page { get; set; }
        public List<KeyValueParameter> Headers { get; set; }
        public List<KeyValueParameter> Parameters { get; set; }
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
}