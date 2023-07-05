using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboCity
{
    public long CityId { get; set; }

    public string? City { get; set; }

    public virtual ICollection<DboAddress> DboAddresses { get; set; } = new List<DboAddress>();
}
