using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbrellaCorpHRSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyAutomatedEmailSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailMessages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Body",
                value: "Dear Employee,\r\n\r\nYour access to the office has been granted. Please use your employee ID to enter the building.\r\nDo Not Reply to this email. This is an automated message from the Umbrella Corp HR System.\r\n\r\nHave a wonderful day,\r\nUmbrella Automated Email System");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailMessages",
                keyColumn: "Id",
                keyValue: 4,
                column: "Body",
                value: "Your access to the office has been granted. Please use your employee ID to enter the building.\r\nDo Not Reply to this email. This is an automated message from the Umbrella Corp HR System.");
        }
    }
}
