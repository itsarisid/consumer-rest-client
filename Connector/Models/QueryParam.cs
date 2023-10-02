using System;
using System.Collections.Generic;

namespace Connector.Models;

public partial class QueryParam
{
    public int Id { get; set; }

    public int? ReqId { get; set; }

    public string? Qkey { get; set; }

    public string? Qvalue { get; set; }

    public bool? IsActive { get; set; }

    public virtual ApiRequest? Req { get; set; }
}
