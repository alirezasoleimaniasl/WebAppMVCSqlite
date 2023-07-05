using System;
using System.Collections.Generic;

namespace LineList.Models;

public partial class DboLabSample
{
    public long SampleId { get; set; }

    public long? LabId { get; set; }

    public string? SamplingDate { get; set; }

    public string? ToLabDate { get; set; }

    public long? TestAnswer { get; set; }

    public long? AnswerDate { get; set; }

    public virtual ICollection<DboPatient> DboPatients { get; set; } = new List<DboPatient>();

    public virtual ICollection<DboLabSample> InverseLab { get; set; } = new List<DboLabSample>();

    public virtual DboLabSample? Lab { get; set; }
}
