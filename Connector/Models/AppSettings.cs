using RestSharp;

namespace Connector.Models
{
    public class AppSettings
    {
        public string? AppName { get; set; }
        public string? BaseUrl { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }
        public AuthenticationParameter? AuthenticationParameter { get; set; }
        public string? OutputDirectory { get; set; } = null;
        public List<RequestModel> Requests { get; set; }

    }
}