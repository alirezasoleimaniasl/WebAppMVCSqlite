using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVCSqlite.Migrations
{
    /// <inheritdoc />
    public partial class City : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Patient_dbo.Hospital_HospitalID",
                table: "dbo.Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Patient_dbo.Laboratory_LabID",
                table: "dbo.Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Patient_dbo.Vaccine_VaccineID",
                table: "dbo.Patient");

            migrationBuilder.DropTable(
                name: "dbo.Laboratory");

            migrationBuilder.DropTable(
                name: "dbo.Vaccine");

            migrationBuilder.DropIndex(
                name: "IX_dbo.Patient_HospitalID",
                table: "dbo.Patient");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "dbo.Patient");

            migrationBuilder.DropColumn(
                name: "InDate",
                table: "dbo.Hospital");

            migrationBuilder.DropColumn(
                name: "OutDate",
                table: "dbo.Hospital");

            migrationBuilder.DropColumn(
                name: "PatientStatus",
                table: "dbo.Hospital");

            migrationBuilder.DropColumn(
                name: "ReferralType",
                table: "dbo.Hospital");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "dbo.Hospital");

            migrationBuilder.RenameColumn(
                name: "VaccineID",
                table: "dbo.Patient",
                newName: "VaccineSituationID");

            migrationBuilder.RenameColumn(
                name: "LabID",
                table: "dbo.Patient",
                newName: "LabSampleID");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Patient_VaccineID",
                table: "dbo.Patient",
                newName: "IX_dbo.Patient_VaccineSituationID");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Patient_LabID",
                table: "dbo.Patient",
                newName: "IX_dbo.Patient_LabSampleID");

            migrationBuilder.AlterColumn<string>(
                name: "UnderlyingDiseasName",
                table: "dbo.PatientStatus",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SymptomsDate",
                table: "dbo.PatientStatus",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AdmissionType",
                table: "dbo.PatientStatus",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HospitalID",
                table: "dbo.PatientStatus",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalInDate",
                table: "dbo.PatientStatus",
                type: "NVARCHAR (1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalOutDate",
                table: "dbo.PatientStatus",
                type: "NVARCHAR (1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HospitalSection",
                table: "dbo.PatientStatus",
                type: "NVARCHAR (1000)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "dbo.Patient",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "dbo.Patient",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Job",
                table: "dbo.Patient",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "dbo.Patient",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "dbo.Patient",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "dbo.Patient",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "dbo.Patient",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "dbo.Hospital",
                type: "NVARCHAR (1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "dbo.LabSample",
                columns: table => new
                {
                    SampleID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LabID = table.Column<long>(type: "INTEGER (1000)", nullable: true),
                    SamplingDate = table.Column<string>(type: "NVARCHAR (1000)", nullable: true),
                    ToLabDate = table.Column<string>(type: "NVARCHAR (1000)", nullable: true),
                    TestAnswer = table.Column<long>(type: "INTEGER", nullable: true),
                    AnswerDate = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LabSample", x => x.SampleID);
                    table.ForeignKey(
                        name: "FK_dbo.LabSample_dbo.LabSample_LabID",
                        column: x => x.LabID,
                        principalTable: "dbo.LabSample",
                        principalColumn: "SampleID");
                });

            migrationBuilder.CreateTable(
                name: "dbo.LabSource",
                columns: table => new
                {
                    LabSourceID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LabName = table.Column<string>(type: "NVARCHAR (1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.LabSource", x => x.LabSourceID);
                });

            migrationBuilder.CreateTable(
                name: "dbo.VaccineSource",
                columns: table => new
                {
                    VaccineID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "NVARCHAR (1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.VaccineSource", x => x.VaccineID);
                });

            migrationBuilder.CreateTable(
                name: "dbo.VaccineSituation",
                columns: table => new
                {
                    VaccineSituationID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "NVARCHAR (1000)", nullable: true),
                    Time = table.Column<string>(type: "NVARCHAR (1000)", nullable: true),
                    Type = table.Column<string>(type: "NVARCHAR (1000)", nullable: true),
                    Check = table.Column<byte[]>(type: "BOOLEAN", nullable: true),
                    VaccineSourceID = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.VaccineSituation", x => x.VaccineSituationID);
                    table.ForeignKey(
                        name: "FK_dbo.VaccineSituation_dbo.VaccineSource_VaccineSourceID",
                        column: x => x.VaccineSourceID,
                        principalTable: "dbo.VaccineSource",
                        principalColumn: "VaccineID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbo.PatientStatus_HospitalID",
                table: "dbo.PatientStatus",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.LabSample_LabID",
                table: "dbo.LabSample",
                column: "LabID");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.VaccineSituation_VaccineSourceID",
                table: "dbo.VaccineSituation",
                column: "VaccineSourceID");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Patient_dbo.LabSample_LabSampleID",
                table: "dbo.Patient",
                column: "LabSampleID",
                principalTable: "dbo.LabSample",
                principalColumn: "SampleID");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Patient_dbo.VaccineSituation_VaccineSituationID",
                table: "dbo.Patient",
                column: "VaccineSituationID",
                principalTable: "dbo.VaccineSituation",
                principalColumn: "VaccineSituationID");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.PatientStatus_dbo.Hospital_HospitalID",
                table: "dbo.PatientStatus",
                column: "HospitalID",
                principalTable: "dbo.Hospital",
                principalColumn: "HospitalID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Patient_dbo.LabSample_LabSampleID",
                table: "dbo.Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Patient_dbo.VaccineSituation_VaccineSituationID",
                table: "dbo.Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.PatientStatus_dbo.Hospital_HospitalID",
                table: "dbo.PatientStatus");

            migrationBuilder.DropTable(
                name: "dbo.LabSample");

            migrationBuilder.DropTable(
                name: "dbo.LabSource");

            migrationBuilder.DropTable(
                name: "dbo.VaccineSituation");

            migrationBuilder.DropTable(
                name: "dbo.VaccineSource");

            migrationBuilder.DropIndex(
                name: "IX_dbo.PatientStatus_HospitalID",
                table: "dbo.PatientStatus");

            migrationBuilder.DropColumn(
                name: "AdmissionType",
                table: "dbo.PatientStatus");

            migrationBuilder.DropColumn(
                name: "HospitalID",
                table: "dbo.PatientStatus");

            migrationBuilder.DropColumn(
                name: "HospitalInDate",
                table: "dbo.PatientStatus");

            migrationBuilder.DropColumn(
                name: "HospitalOutDate",
                table: "dbo.PatientStatus");

            migrationBuilder.DropColumn(
                name: "HospitalSection",
                table: "dbo.PatientStatus");

            migrationBuilder.RenameColumn(
                name: "VaccineSituationID",
                table: "dbo.Patient",
                newName: "VaccineID");

            migrationBuilder.RenameColumn(
                name: "LabSampleID",
                table: "dbo.Patient",
                newName: "LabID");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Patient_VaccineSituationID",
                table: "dbo.Patient",
                newName: "IX_dbo.Patient_VaccineID");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Patient_LabSampleID",
                table: "dbo.Patient",
                newName: "IX_dbo.Patient_LabID");

            migrationBuilder.AlterColumn<string>(
                name: "UnderlyingDiseasName",
                table: "dbo.PatientStatus",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SymptomsDate",
                table: "dbo.PatientStatus",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "dbo.Patient",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "dbo.Patient",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Job",
                table: "dbo.Patient",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "dbo.Patient",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "dbo.Patient",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FatherName",
                table: "dbo.Patient",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "dbo.Patient",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HospitalID",
                table: "dbo.Patient",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "dbo.Hospital",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR (1000)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InDate",
                table: "dbo.Hospital",
                type: "NVARCHAR(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OutDate",
                table: "dbo.Hospital",
                type: "NVARCHAR(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientStatus",
                table: "dbo.Hospital",
                type: "NVARCHAR(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferralType",
                table: "dbo.Hospital",
                type: "NVARCHAR(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "dbo.Hospital",
                type: "NVARCHAR(1000)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "dbo.Laboratory",
                columns: table => new
                {
                    LabID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnswerDate = table.Column<long>(type: "INTEGER", nullable: true),
                    LabName = table.Column<string>(type: "NVARCHAR(1000)", nullable: true),
                    SamplingDate = table.Column<string>(type: "NVARCHAR(1000)", nullable: true),
                    TestAnswer = table.Column<long>(type: "INTEGER", nullable: true),
                    ToLabDate = table.Column<string>(type: "NVARCHAR(1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Laboratory", x => x.LabID);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Vaccine",
                columns: table => new
                {
                    VaccineID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Check = table.Column<byte[]>(type: "BOOLEAN", nullable: true),
                    Date = table.Column<string>(type: "NVARCHAR (1000)", nullable: true),
                    Time = table.Column<string>(type: "NVARCHAR (1000)", nullable: true),
                    Type = table.Column<string>(type: "NVARCHAR (1000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Vaccine", x => x.VaccineID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Patient_HospitalID",
                table: "dbo.Patient",
                column: "HospitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Patient_dbo.Hospital_HospitalID",
                table: "dbo.Patient",
                column: "HospitalID",
                principalTable: "dbo.Hospital",
                principalColumn: "HospitalID");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Patient_dbo.Laboratory_LabID",
                table: "dbo.Patient",
                column: "LabID",
                principalTable: "dbo.Laboratory",
                principalColumn: "LabID");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Patient_dbo.Vaccine_VaccineID",
                table: "dbo.Patient",
                column: "VaccineID",
                principalTable: "dbo.Vaccine",
                principalColumn: "VaccineID");
        }
    }
}
