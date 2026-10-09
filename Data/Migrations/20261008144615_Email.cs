using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UmbrellaCorpHRSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailThreads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailThreads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailThreadId = table.Column<int>(type: "int", nullable: false),
                    SenderEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(2056)", maxLength: 2056, nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailMessages_EmailThreads_EmailThreadId",
                        column: x => x.EmailThreadId,
                        principalTable: "EmailThreads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EmailThreads",
                columns: new[] { "Id", "RecipientEmail", "SenderEmail" },
                values: new object[,]
                {
                    { 1, "claireredfield@umbrellacorp.com", "albertwesker@umbrellacorp.com" },
                    { 2, "claireredfield@umbrellacorp.com", "jamesmarcus@umbrellacorp.com" },
                    { 3, "claireredfield@umbrellacorp.com", "automated@umbrellacorp.com" }
                });

            migrationBuilder.InsertData(
                table: "EmailMessages",
                columns: new[] { "Id", "Body", "EmailThreadId", "RecipientEmail", "SenderEmail", "SentDate", "Subject" },
                values: new object[,]
                {
                    { 1, "Hello Claire,\r\nWelcome to Umbrella corp.\r\nBest regards,\r\nA. Wesker", 1, "claireredfield@umbrellacorp.com", "albertwesker@umbrellacorp.com", new DateTime(2025, 6, 6, 14, 19, 35, 0, DateTimeKind.Unspecified), "Welcome Claire" },
                    { 2, "Hi Claire,\r\nLet's have a meeting at 3 PM today to discuss your onboarding process.\r\nBest regards,\r\nJ. Marcus", 2, "claireredfield@umbrellacorp.com", "jamesmarcus@umbrellacorp.com", new DateTime(2025, 6, 6, 11, 34, 5, 0, DateTimeKind.Unspecified), "Welcome to Umbrella Corp" },
                    { 3, "Sorry, forgot to mention that the meeting will be held in the conference room on the 2nd floor.\r\nJ. Marcus", 2, "claireredfield@umbrellacorp.com", "jamesmarcus@umbrellacorp.com", new DateTime(2025, 6, 6, 11, 36, 54, 0, DateTimeKind.Unspecified), "Re: Welcome to Umbrella Corp" },
                    { 4, "Your access to the office has been granted. Please use your employee ID to enter the building.\r\nDo Not Reply to this email. This is an automated message from the Umbrella Corp HR System.", 3, "claireredfield@umbrellacorp.com", "automated@umbrellacorp.com", new DateTime(2025, 6, 5, 23, 59, 59, 0, DateTimeKind.Unspecified), "Welcome to Umbrella Corp HR System" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailMessages_EmailThreadId",
                table: "EmailMessages",
                column: "EmailThreadId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailMessages");

            migrationBuilder.DropTable(
                name: "EmailThreads");
        }
    }
}
