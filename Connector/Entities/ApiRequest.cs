using System;
using System.Collections.Generic;

namespace Connector.Entities;

public partial class ApiRequest
{
    public int Id { get; set; }

    public int? ApiId { get; set; }

    public string? BaseUrl { get; set; }

    public string? ResourceUrl { get; set; }

    public string? NextUrl { get; set; }

    public string? ContentType { get; set; }

    public string? Method { get; set; }

    public string? RequestBody { get; set; }

    public string? Body { get; set; }

    public bool? IsSuccessful { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ApiDetail? Api { get; set; }

    public virtual ICollection<Header> Headers { get; set; } = new List<Header>();

    public virtual ICollection<QueryParameter> QueryParameters { get; set; } = new List<QueryParameter>();
}
