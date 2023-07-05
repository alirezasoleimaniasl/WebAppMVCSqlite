using System;
using System.Collections.Generic;
using LineList.Models;
using Microsoft.EntityFrameworkCore;

namespace LineList.Data;

public partial class LineListContext : DbContext
{
    public LineListContext(DbContextOptions<LineListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DboAddress> DboAddresses { get; set; }

    public virtual DbSet<DboCity> DboCities { get; set; }

    public virtual DbSet<DboHospital> DboHospitals { get; set; }

    public virtual DbSet<DboLabSample> DboLabSamples { get; set; }

    public virtual DbSet<DboLabSource> DboLabSources { get; set; }

    public virtual DbSet<DboPatient> DboPatients { get; set; }

    public virtual DbSet<DboPatientStatus> DboPatientStatuses { get; set; }

    public virtual DbSet<DboSysdiagram> DboSysdiagrams { get; set; }

    public virtual DbSet<DboVaccineSituation> DboVaccineSituations { get; set; }

    public virtual DbSet<DboVaccineSource> DboVaccineSources { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DboAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("dbo.Address");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.CityId)
                .HasColumnType("INTEGER (1000)")
                .HasColumnName("CityID");
            entity.Property(e => e.FullAddress).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.PhoneNumber).HasColumnType("NVARCHAR (1000)");

            entity.HasOne(d => d.City).WithMany(p => p.DboAddresses).HasForeignKey(d => d.CityId);
        });

        modelBuilder.Entity<DboCity>(entity =>
        {
            entity.HasKey(e => e.CityId);

            entity.ToTable("dbo.City");

            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.City).HasColumnType("NVARCHAR (1000)");
        });

        modelBuilder.Entity<DboHospital>(entity =>
        {
            entity.HasKey(e => e.HospitalId);

            entity.ToTable("dbo.Hospital");

            entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
            entity.Property(e => e.Name).HasColumnType("NVARCHAR (1000)");
        });

        modelBuilder.Entity<DboLabSample>(entity =>
        {
            entity.HasKey(e => e.SampleId);

            entity.ToTable("dbo.LabSample");

            entity.Property(e => e.SampleId).HasColumnName("SampleID");
            entity.Property(e => e.LabId)
                .HasColumnType("INTEGER (1000)")
                .HasColumnName("LabID");
            entity.Property(e => e.SamplingDate).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.ToLabDate).HasColumnType("NVARCHAR (1000)");

            entity.HasOne(d => d.Lab).WithMany(p => p.InverseLab).HasForeignKey(d => d.LabId);
        });

        modelBuilder.Entity<DboLabSource>(entity =>
        {
            entity.HasKey(e => e.LabSourceId);

            entity.ToTable("dbo.LabSource");

            entity.Property(e => e.LabSourceId).HasColumnName("LabSourceID");
            entity.Property(e => e.LabName).HasColumnType("NVARCHAR (1000)");
        });

        modelBuilder.Entity<DboPatient>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("dbo.Patient");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.DateOfBirth).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.FatherName).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.FirstName).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.Gender).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.Job).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.LabSampleId).HasColumnName("LabSampleID");
            entity.Property(e => e.LastName).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.NationalCode).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.PatientStatusId).HasColumnName("PatientStatusID");
            entity.Property(e => e.VaccineSituationId).HasColumnName("VaccineSituationID");

            entity.HasOne(d => d.Address).WithMany(p => p.DboPatients).HasForeignKey(d => d.AddressId);

            entity.HasOne(d => d.LabSample).WithMany(p => p.DboPatients).HasForeignKey(d => d.LabSampleId);

            entity.HasOne(d => d.PatientStatus).WithMany(p => p.DboPatients).HasForeignKey(d => d.PatientStatusId);

            entity.HasOne(d => d.VaccineSituation).WithMany(p => p.DboPatients).HasForeignKey(d => d.VaccineSituationId);
        });

        modelBuilder.Entity<DboPatientStatus>(entity =>
        {
            entity.HasKey(e => e.PatientStatusId);

            entity.ToTable("dbo.PatientStatus");

            entity.Property(e => e.PatientStatusId).HasColumnName("PatientStatusID");
            entity.Property(e => e.HospitalId).HasColumnName("HospitalID");
            entity.Property(e => e.HospitalInDate).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.HospitalOutDate).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.HospitalSection).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.SymptomsDate).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.UnderlyingDiseasName).HasColumnType("NVARCHAR (1000)");

            entity.HasOne(d => d.Hospital).WithMany(p => p.DboPatientStatuses).HasForeignKey(d => d.HospitalId);
        });

        modelBuilder.Entity<DboSysdiagram>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("dbo.sysdiagrams");

            entity.Property(e => e.Definition).HasColumnName("definition");
            entity.Property(e => e.DiagramId).HasColumnName("diagram_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.PrincipalId).HasColumnName("principal_id");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<DboVaccineSituation>(entity =>
        {
            entity.HasKey(e => e.VaccineSituationId);

            entity.ToTable("dbo.VaccineSituation");

            entity.Property(e => e.VaccineSituationId).HasColumnName("VaccineSituationID");
            entity.Property(e => e.Check).HasColumnType("BOOLEAN");
            entity.Property(e => e.Date).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.Time).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.Type).HasColumnType("NVARCHAR (1000)");
            entity.Property(e => e.VaccineSourceId).HasColumnName("VaccineSourceID");

            entity.HasOne(d => d.VaccineSource).WithMany(p => p.DboVaccineSituations).HasForeignKey(d => d.VaccineSourceId);
        });

        modelBuilder.Entity<DboVaccineSource>(entity =>
        {
            entity.HasKey(e => e.VaccineId);

            entity.ToTable("dbo.VaccineSource");

            entity.Property(e => e.VaccineId).HasColumnName("VaccineID");
            entity.Property(e => e.Type).HasColumnType("NVARCHAR (1000)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
