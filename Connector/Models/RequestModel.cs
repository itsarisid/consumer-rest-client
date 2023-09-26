using Newtonsoft.Json;

namespace Connector.Models
{
    public class RequestModel
    {
        public string Method { get; set; }
        public string Uri { get; set; }
        public List<HeaderModel> Headers { get; set; }
        public List<ParameterModel> Parameters { get; set; }
    }

    public class HeaderModel
    {
        [JsonProperty("app-id")]
        public string appid { get; set; }
    }

    public class ParameterModel
    {
        [JsonProperty("app-id")]
        public string appid { get; set; }
    }
}