using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboSysdiagram
{
    public byte[]? Name { get; set; }

    public byte[]? PrincipalId { get; set; }

    public byte[]? DiagramId { get; set; }

    public byte[]? Version { get; set; }

    public byte[]? Definition { get; set; }
}
