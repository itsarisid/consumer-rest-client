using System;
using System.Collections.Generic;

namespace Connector.Models;

public partial class Header
{
    public int Id { get; set; }

    public int? ReqId { get; set; }

    public string? Hkey { get; set; }

    public string? Hvalue { get; set; }

    public bool? IsActive { get; set; }

    public virtual ApiRequest? Req { get; set; }
}
