namespace Connector
{
    /// <summary>
    ///   <br />
    /// </summary>
    public enum AuthenticatorType
    {
        None,
        Basic,
        OAuth1,
        OAuth2,
        JWT,
        Custom
    }

    /// <summary>
    ///   <br />
    /// </summary>
    public enum RequestBodyType
    {
        STRING, // For the String body
        JSON, // Serialize the object in to JSON
        XML // Serialize the object in to XML
    }

}
