﻿using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboHospital
{
    public long HospitalId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<DboPatientStatus> DboPatientStatuses { get; set; } = new List<DboPatientStatus>();
}
