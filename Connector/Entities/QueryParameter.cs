using System;
using System.Collections.Generic;

namespace Connector.Entities;

public partial class QueryParameter
{
    public int Id { get; set; }

    public int? ReqId { get; set; }

    public string? Key { get; set; }

    public string? Value { get; set; }

    public bool? IsActive { get; set; }

    public virtual ApiRequest? Req { get; set; }
}
