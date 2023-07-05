using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboVaccineSource
{
    public long VaccineId { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<DboVaccineSituation> DboVaccineSituations { get; set; } = new List<DboVaccineSituation>();
}
