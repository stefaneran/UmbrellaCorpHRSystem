using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UmbrellaCorpHRSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditSeedsForNarrative : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "EmailThreads",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "EmailMessages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "Hello Claire,\r\nWelcome to Umbrella corp.\r\n\r\nI am aware that you are yet to have your onboarding session with Marcus, but I would like to ask you to deal with some urgent tasks in the meantime. They will take you 7 minutes, if you can spare them:\r\n\r\n- Please increase Arthur Pendleton's salary to 112,000\r\n- Kindly terminate Frank Hughes's contract \r\n- Inform Mei Lin that she may not make any more Amazon orders directly to the facillity\r\n- Finally, throw a pizza party through the office control panel to reward our employees for their most recent discovery\r\n\r\nBest regards,\r\nA. Wesker", "Welcome Claire a few favors please" });

            migrationBuilder.UpdateData(
                table: "EmailThreads",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsRead",
                value: false);

            migrationBuilder.UpdateData(
                table: "EmailThreads",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsRead",
                value: false);

            migrationBuilder.UpdateData(
                table: "EmailThreads",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsRead",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "EmailThreads");

            migrationBuilder.UpdateData(
                table: "EmailMessages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "Subject" },
                values: new object[] { "Hello Claire,\r\nWelcome to Umbrella corp.\r\nBest regards,\r\nA. Wesker", "Welcome Claire" });
        }
    }
}
