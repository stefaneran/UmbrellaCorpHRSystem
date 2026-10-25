using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbrellaCorpHRSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeClaireUninfectedOnSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HeartRate", "InfectionStatus" },
                values: new object[] { 65, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HeartRate", "InfectionStatus" },
                values: new object[] { 121, 2 });
        }
    }
}
