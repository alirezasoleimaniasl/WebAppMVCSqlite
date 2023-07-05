using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboPatientStatus
{
    public long PatientStatusId { get; set; }

    public string? SymptomsDate { get; set; }

    public long? HistoryOfCovid { get; set; }

    public long? IsPregnant { get; set; }

    public long? UnderlyingDiseas { get; set; }

    public string? UnderlyingDiseasName { get; set; }

    public string? HospitalInDate { get; set; }

    public string? HospitalSection { get; set; }

    public string? HospitalOutDate { get; set; }

    public long? AdmissionType { get; set; }

    public long? HospitalId { get; set; }

    public virtual ICollection<DboPatient> DboPatients { get; set; } = new List<DboPatient>();

    public virtual DboHospital? Hospital { get; set; }
}
