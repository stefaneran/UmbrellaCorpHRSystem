using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UmbrellaCorpHRSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class EmployeesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    TotalAnnualLeave = table.Column<int>(type: "int", nullable: false),
                    UsedAnnualLeave = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    EmploymentType = table.Column<int>(type: "int", nullable: false),
                    EmploymentStatus = table.Column<int>(type: "int", nullable: false),
                    HeartRate = table.Column<int>(type: "int", nullable: false),
                    CurrentLocation = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    InfectionStatus = table.Column<int>(type: "int", nullable: false),
                    LifeStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CurrentLocation", "Department", "Email", "EmploymentStatus", "EmploymentType", "FirstName", "HeartRate", "InfectionStatus", "LastName", "LifeStatus", "Salary", "TotalAnnualLeave", "UsedAnnualLeave" },
                values: new object[,]
                {
                    { 1, "Executive Offices", 1, "albertwesker@umbrellacorp.com", 1, 1, "Albert", 65, 1, "Wesker", 1, 384000, 32, 1 },
                    { 2, "Executive Offices", 1, "jamesmarcus@umbrellacorp.com", 1, 1, "James", 66, 1, "Marcus", 1, 326000, 30, 3 },
                    { 3, "Administrative Office", 8, "claireredfield@umbrellacorp.com", 1, 1, "Claire", 121, 2, "Redfield", 1, 84000, 22, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
