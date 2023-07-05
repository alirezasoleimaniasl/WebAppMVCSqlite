using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboVaccineSituation
{
    public long VaccineSituationId { get; set; }

    public string? Date { get; set; }

    public string? Time { get; set; }

    public string? Type { get; set; }

    public byte[]? Check { get; set; }

    public long? VaccineSourceId { get; set; }

    public virtual ICollection<DboPatient> DboPatients { get; set; } = new List<DboPatient>();

    public virtual DboVaccineSource? VaccineSource { get; set; }
}
