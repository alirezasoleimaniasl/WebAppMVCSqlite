using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppMVCSqlite.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Check",
                table: "dbo.Vaccine",
                type: "BOOLEAN",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "dbo.Hospital",
                type: "NVARCHAR(1000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Check",
                table: "dbo.Vaccine",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BOOLEAN",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "dbo.Hospital",
                type: "NVARCHAR(1000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldNullable: true);
        }
    }
}
