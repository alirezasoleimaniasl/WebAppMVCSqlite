using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboHospitalSection
{
    public long HospitalSectionId { get; set; }

    public string? HospitalSectionName { get; set; }

    public virtual ICollection<DboHospital> DboHospitals { get; set; } = new List<DboHospital>();
}
