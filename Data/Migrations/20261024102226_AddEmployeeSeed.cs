using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UmbrellaCorpHRSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CurrentLocation", "Department", "Email", "EmploymentStatus", "EmploymentType", "FirstName", "HeartRate", "InfectionStatus", "LastName", "LifeStatus", "Salary", "TotalAnnualLeave", "UsedAnnualLeave" },
                values: new object[,]
                {
                    { 4, "Executive Offices", 1, "sergeivladimir@umbrellacorp.com", 1, 1, "Sergei", 68, 1, "Vladimir", 1, 298000, 30, 4 },
                    { 5, "Executive Offices", 1, "margarethollis@umbrellacorp.com", 1, 1, "Margaret", 71, 1, "Hollis", 1, 265000, 30, 9 },
                    { 6, "Executive Offices", 1, "richardthornton@umbrellacorp.com", 1, 1, "Richard", 74, 1, "Thornton", 1, 252000, 28, 12 },
                    { 7, "Labs", 2, "williambirkin@umbrellacorp.com", 1, 1, "William", 72, 1, "Birkin", 1, 176000, 26, 0 },
                    { 8, "Labs", 2, "annettebirkin@umbrellacorp.com", 1, 1, "Annette", 70, 1, "Birkin", 1, 164000, 26, 2 },
                    { 9, "Labs", 2, "elenapetrova@umbrellacorp.com", 1, 1, "Elena", 66, 1, "Petrova", 1, 128000, 25, 6 },
                    { 10, "Labs", 2, "danielokafor@umbrellacorp.com", 1, 1, "Daniel", 63, 1, "Okafor", 1, 118000, 25, 10 },
                    { 11, "Labs", 2, "hannahlindqvist@umbrellacorp.com", 1, 1, "Hannah", 69, 1, "Lindqvist", 1, 112000, 25, 3 },
                    { 12, "Labs", 2, "victorramos@umbrellacorp.com", 2, 1, "Victor", 75, 1, "Ramos", 1, 109000, 25, 14 },
                    { 13, "Labs", 2, "gracewhitmore@umbrellacorp.com", 1, 2, "Grace", 62, 1, "Whitmore", 1, 64000, 15, 5 },
                    { 14, "Labs", 2, "thomasbecker@umbrellacorp.com", 1, 1, "Thomas", 71, 1, "Becker", 1, 104000, 24, 8 },
                    { 15, "Labs", 2, "naomifujita@umbrellacorp.com", 1, 1, "Naomi", 67, 1, "Fujita", 1, 121000, 25, 1 },
                    { 16, "Labs", 2, "samuelortiz@umbrellacorp.com", 1, 3, "Samuel", 73, 1, "Ortiz", 1, 98000, 20, 0 },
                    { 17, "Labs", 2, "ingriddahl@umbrellacorp.com", 1, 1, "Ingrid", 64, 1, "Dahl", 1, 115000, 25, 11 },
                    { 18, "Labs", 2, "lenahoffmann@umbrellacorp.com", 1, 1, "Lena", 66, 1, "Hoffmann", 1, 107000, 25, 5 },
                    { 19, "IT Room", 3, "kevinbrandt@umbrellacorp.com", 1, 1, "Kevin", 70, 1, "Brandt", 1, 97000, 24, 7 },
                    { 20, "IT Room", 3, "priyanair@umbrellacorp.com", 1, 1, "Priya", 65, 1, "Nair", 1, 112000, 24, 4 },
                    { 21, "IT Room", 3, "lucasmoreau@umbrellacorp.com", 1, 3, "Lucas", 72, 1, "Moreau", 1, 88000, 20, 2 },
                    { 22, "IT Room", 3, "aikotanaka@umbrellacorp.com", 1, 1, "Aiko", 61, 1, "Tanaka", 1, 104000, 24, 9 },
                    { 23, "IT Room", 3, "jordanellis@umbrellacorp.com", 1, 2, "Jordan", 76, 1, "Ellis", 1, 52000, 14, 3 },
                    { 24, "IT Room", 3, "felixnovak@umbrellacorp.com", 1, 1, "Felix", 68, 1, "Novak", 1, 93000, 24, 13 },
                    { 25, "IT Room", 3, "rachelkim@umbrellacorp.com", 1, 1, "Rachel", 66, 1, "Kim", 1, 101000, 24, 6 },
                    { 26, "Out of Site", 4, "olivergrant@umbrellacorp.com", 1, 1, "Oliver", 69, 1, "Grant", 1, 78000, 22, 8 },
                    { 27, "Out of Site", 4, "sofiamarin@umbrellacorp.com", 1, 1, "Sofia", 63, 1, "Marin", 1, 74000, 22, 5 },
                    { 28, "Out of Site", 4, "henrycaldwell@umbrellacorp.com", 1, 1, "Henry", 77, 1, "Caldwell", 1, 86000, 23, 15 },
                    { 29, "Out of Site", 4, "leilahaddad@umbrellacorp.com", 1, 3, "Leila", 67, 1, "Haddad", 1, 69000, 20, 1 },
                    { 30, "Out of Site", 4, "patrickdoyle@umbrellacorp.com", 2, 1, "Patrick", 79, 1, "Doyle", 1, 71000, 22, 18 },
                    { 31, "Security Room", 5, "nicholaiginovaef@umbrellacorp.com", 1, 3, "Nicholai", 60, 1, "Ginovaef", 1, 82000, 20, 0 },
                    { 32, "Lobby", 5, "carlosoliveira@umbrellacorp.com", 1, 3, "Carlos", 72, 1, "Oliveira", 1, 61000, 20, 2 },
                    { 33, "Corridor A", 5, "mikhailvictor@umbrellacorp.com", 1, 3, "Mikhail", 64, 1, "Victor", 1, 74000, 20, 4 },
                    { 34, "Corridor B", 5, "derekstone@umbrellacorp.com", 1, 1, "Derek", 70, 1, "Stone", 1, 66000, 22, 7 },
                    { 35, "Corridor C", 5, "isabelcruz@umbrellacorp.com", 1, 1, "Isabel", 68, 1, "Cruz", 1, 63000, 22, 10 },
                    { 36, "Labs", 5, "ryanmitchell@umbrellacorp.com", 1, 1, "Ryan", 74, 1, "Mitchell", 1, 59000, 22, 5 },
                    { 37, "Executive Offices", 5, "tomaskowalski@umbrellacorp.com", 1, 1, "Tomas", 71, 1, "Kowalski", 1, 62000, 22, 12 },
                    { 38, "Security Room", 5, "dmitrivolkov@umbrellacorp.com", 1, 3, "Dmitri", 62, 1, "Volkov", 1, 71000, 20, 3 },
                    { 39, "Administrative Office", 5, "angelaprice@umbrellacorp.com", 1, 1, "Angela", 66, 1, "Price", 1, 64000, 22, 9 },
                    { 40, "Accounting Office", 5, "marcobianchi@umbrellacorp.com", 1, 1, "Marco", 75, 1, "Bianchi", 1, 58000, 22, 1 },
                    { 41, "IT Room", 5, "owenfletcher@umbrellacorp.com", 1, 2, "Owen", 73, 1, "Fletcher", 1, 34000, 12, 2 },
                    { 42, "Lobby", 5, "yusufdemir@umbrellacorp.com", 1, 1, "Yusuf", 69, 1, "Demir", 1, 60000, 22, 6 },
                    { 43, "Boiler Room", 6, "frankhughes@umbrellacorp.com", 1, 1, "Frank", 74, 1, "Hughes", 1, 46000, 20, 8 },
                    { 44, "Ventilation Shafts", 6, "georgemiller@umbrellacorp.com", 1, 1, "George", 78, 1, "Miller", 1, 44000, 20, 12 },
                    { 45, "Lobby", 6, "rosadelgado@umbrellacorp.com", 1, 1, "Rosa", 67, 1, "Delgado", 1, 42000, 20, 4 },
                    { 46, "Corridor A", 6, "walterbriggs@umbrellacorp.com", 1, 1, "Walter", 80, 1, "Briggs", 1, 48000, 21, 16 },
                    { 47, "Corridor B", 6, "eddiewalsh@umbrellacorp.com", 2, 3, "Eddie", 76, 1, "Walsh", 1, 39000, 18, 0 },
                    { 48, "Corridor C", 6, "stanleycooper@umbrellacorp.com", 1, 2, "Stanley", 71, 1, "Cooper", 1, 24000, 10, 3 },
                    { 49, "Boiler Room", 6, "martinreyes@umbrellacorp.com", 1, 1, "Martin", 65, 1, "Reyes", 1, 45000, 20, 7 },
                    { 50, "Ventilation Shafts", 6, "guspatterson@umbrellacorp.com", 1, 1, "Gus", 79, 1, "Patterson", 1, 47000, 20, 14 },
                    { 51, "Lobby", 6, "lindamoore@umbrellacorp.com", 1, 2, "Linda", 68, 1, "Moore", 1, 23000, 10, 2 },
                    { 52, "Accounting Office", 7, "catherineblake@umbrellacorp.com", 1, 1, "Catherine", 66, 1, "Blake", 1, 118000, 25, 6 },
                    { 53, "Accounting Office", 7, "arthurpendleton@umbrellacorp.com", 1, 1, "Arthur", 72, 1, "Pendleton", 1, 104000, 25, 11 },
                    { 54, "Accounting Office", 7, "meilin@umbrellacorp.com", 1, 1, "Mei", 63, 1, "Lin", 1, 96000, 24, 3 },
                    { 55, "Accounting Office", 7, "robertvance@umbrellacorp.com", 1, 1, "Robert", 70, 1, "Vance", 1, 89000, 24, 9 },
                    { 56, "Accounting Office", 7, "juliahartmann@umbrellacorp.com", 1, 2, "Julia", 65, 1, "Hartmann", 1, 47000, 14, 4 },
                    { 57, "Accounting Office", 7, "nathansorensen@umbrellacorp.com", 1, 3, "Nathan", 71, 1, "Sorensen", 1, 82000, 20, 0 },
                    { 58, "Administrative Office", 8, "emilycarter@umbrellacorp.com", 1, 1, "Emily", 67, 1, "Carter", 1, 76000, 22, 5 },
                    { 59, "Administrative Office", 8, "dianarusso@umbrellacorp.com", 1, 1, "Diana", 64, 1, "Russo", 1, 72000, 22, 8 },
                    { 60, "Administrative Office", 8, "paulwhitaker@umbrellacorp.com", 1, 1, "Paul", 73, 1, "Whitaker", 1, 81000, 23, 13 },
                    { 61, "Administrative Office", 8, "fatimarahman@umbrellacorp.com", 1, 1, "Fatima", 62, 1, "Rahman", 1, 69000, 22, 2 },
                    { 62, "Administrative Office", 8, "laurabenson@umbrellacorp.com", 1, 2, "Laura", 70, 1, "Benson", 1, 36000, 12, 1 },
                    { 63, "Administrative Office", 8, "simonhayes@umbrellacorp.com", 1, 3, "Simon", 68, 1, "Hayes", 1, 64000, 20, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 63);
        }
    }
}
