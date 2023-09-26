using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Connector.Models
{
    public class RequestModel
    {
        public string Method { get; set; }
        public string Uri { get; set; }
        public List<KeyValueParameter> Headers { get; set; }
        public List<KeyValueParameter> Parameters { get; set; }
    }

    public class KeyValueParameter
    {
        public string Key { get; set; } 
        public string Value { get; set; }
    }
}