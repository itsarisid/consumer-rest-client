using System;
using System.Collections.Generic;

namespace Connector.Models;

public partial class ApiRequest
{
    public int Id { get; set; }

    public int? ApiId { get; set; }

    public string? BaseUrl { get; set; }

    public string? ResourceUrl { get; set; }

    public string? NextUrl { get; set; }

    public bool? IsSuccessfull { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ApiDetail? Api { get; set; }

    public virtual ICollection<Header> Headers { get; set; } = new List<Header>();

    public virtual ICollection<QueryParam> QueryParams { get; set; } = new List<QueryParam>();
}
