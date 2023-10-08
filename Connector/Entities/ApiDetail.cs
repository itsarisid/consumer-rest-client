using System;
using System.Collections.Generic;

namespace Connector.Entities;

public partial class ApiDetail
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? AuthUrl { get; set; }

    public string? Method { get; set; }

    public string? AuthType { get; set; }

    public string? ConsumerKey { get; set; }

    public string? ConsumerSecret { get; set; }

    public string? Token { get; set; }

    public string? OauthToken { get; set; }

    public string? OauthTokenSecret { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Body { get; set; }

    public string? Apikey { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<ApiRequest> ApiRequests { get; set; } = new List<ApiRequest>();
}
