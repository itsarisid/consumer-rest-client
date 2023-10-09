namespace Connector.Models
{
    /// <summary>Authentication Parameter</summary>
    public record AuthenticationParameter
    {
        public string? Token { get; set; }
        public string? ConsumerKey { get; set; }
        public string? ConsumerSecret { get; set; }
        public string? OAuthToken { get; set; }
        public string? OAuthTokenSecret { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? APIKey { get; set; }
        public string? URL { get; set; }
    }
}
