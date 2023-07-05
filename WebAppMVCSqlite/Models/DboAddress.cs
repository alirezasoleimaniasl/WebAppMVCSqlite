using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboAddress
{
    public long AddressId { get; set; }

    public long? CityId { get; set; }

    public string? FullAddress { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual DboCity? City { get; set; }

    public virtual ICollection<DboPatient> DboPatients { get; set; } = new List<DboPatient>();
}
