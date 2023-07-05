using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboPatient
{
    public long PatientId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? NationalCode { get; set; }

    public string? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Job { get; set; }

    public string? FatherName { get; set; }

    public long? PatientStatusId { get; set; }

    public long? VaccineSituationId { get; set; }

    public long? LabSampleId { get; set; }

    public long? AddressId { get; set; }

    public virtual DboAddress? Address { get; set; }

    public virtual DboLabSample? LabSample { get; set; }

    public virtual DboPatientStatus? PatientStatus { get; set; }

    public virtual DboVaccineSituation? VaccineSituation { get; set; }
}
