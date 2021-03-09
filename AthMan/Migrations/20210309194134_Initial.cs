using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AthMan.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    YearlyPrice = table.Column<decimal>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryID = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateOpened = table.Column<DateTime>(nullable: false),
                    DateClosed = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentID);
                    table.ForeignKey(
                        name: "FK_Incidents_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidents_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ItemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryID", "Name" },
                values: new object[,]
                {
                    { "AU", "Australia" },
                    { "NZ", "New Zealand" },
                    { "NG", "Nigeria" },
                    { "PH", "Philippines" },
                    { "PR", "Puerto Rico" },
                    { "QA", "Qatar" },
                    { "SG", "Singapore" },
                    { "ES", "Spain" },
                    { "SE", "Sweden" },
                    { "CH", "Switzerland" },
                    { "TH", "Thailand" },
                    { "TR", "Turkey" },
                    { "UA", "Ukraine" },
                    { "AE", "United Arab Emirates" },
                    { "GB", "United Kingdom" },
                    { "US", "United States" },
                    { "VN", "Vietnam" },
                    { "ZW", "Zimbabwe" },
                    { "NL", "Netherlands" },
                    { "MX", "Mexico" },
                    { "PT", "Portugal" },
                    { "LR", "Liberia" },
                    { "AT", "Austria" },
                    { "BE", "Belgium" },
                    { "BR", "Brazil" },
                    { "MY", "Malaysia" },
                    { "CN", "China" },
                    { "DK", "Denmark" },
                    { "FI", "Finland" },
                    { "FR", "France" },
                    { "GR", "Greece" },
                    { "CA", "Canada" },
                    { "HK", "Hong Kong" },
                    { "IS", "Iceland" },
                    { "IN", "India" },
                    { "IE", "Ireland" },
                    { "IL", "Israel" },
                    { "IT", "Italy" },
                    { "JP", "Japan" },
                    { "GL", "Greenland" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 15, "tfiori@athman.com", "Tina Fiori", "800-555-1459" },
                    { 14, "gwendt@athman.com", "George Wendt", "800-555-1400" },
                    { 12, "jason@athman.com", "Jason Lea", "800-555-1444" },
                    { 11, "alie@athman.com", "Alie Diaz", "800-555-1443" },
                    { 13, "andy@athman.com", "Andy Wilson", "800-555-1449" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "ItemCode", "Name", "ReleaseDate", "YearlyPrice" },
                values: new object[,]
                {
                    { 6, "TRNY10", "Tournament Master 1.0", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 1, "DRFT15", "Draft Manager 1.5", new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 2, "DRFT24", "Draft Manager 2.4", new DateTime(2020, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m },
                    { 3, "LEAG11", "League Scheduler 1.1", new DateTime(2019, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 4, "LEAGD20", "League Scheduler Deluxe 2.0", new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7.99m },
                    { 5, "TEAM10", "Team Manager 1.0", new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.99m },
                    { 7, "TRNY20", "Tournament Master 2.0", new DateTime(2020, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5.99m }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientID", "Address", "City", "CountryID", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1002, "PO Box 96621", "Washington", "US", "anita@mma.nidc.com", "Anita", "Ervin", "(301) 555-8950", "20090", "DC" },
                    { 1004, "1990 Westwood Blvd Ste 260", "Los Angeles", "US", "kenzie@mma.jobtrak.com", "Kenzie", "Quinne", "(800) 555-8725", "90025", "CA" },
                    { 1006, "3255 Ramos Cir", "Sacramento", "US", "amauro@yahoo.org", "Anton", "Mauro", "(916) 555-6670", "95827", "CA" },
                    { 1008, "Box 52001", "San Francisco", "US", "kanthoni@pge.com", "Kaitlin", "Anthoni", "(800) 555-6081", "94152", "CA" },
                    { 1010, "PO Box 2069", "Fresno", "US", "kmay@fresno.ca.gov", "Kendall", "May", "(559) 555-9999", "93718", "CA" },
                    { 1012, "4420 N. First Street, Suite 108", "Fresno", "US", "marvin@expedata.com", "Marvin", "Keeton", "(559) 555-9586", "93726", "CA" },
                    { 1015, "27371 Valderas", "Mission Viejo", "US", "", "Gonzalo", "Quintin", "(214) 555-3647", "92691", "CA" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentID", "ClientID", "DateClosed", "DateOpened", "Description", "EmployeeID", "ItemID", "Title" },
                values: new object[,]
                {
                    { 2, 1002, null, new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Received error message 415 while trying to import data from previous version.", 14, 4, "Error importing data" },
                    { 1, 1010, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media appears to be bad.", 11, 1, "Could not install" },
                    { 4, 1010, null, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Program fails with error code 510, unable to open database.", null, 3, "Error launching program" },
                    { 3, 1015, new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Setup failed with code 104.", 15, 6, "Could not install" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CountryID",
                table: "Clients",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ClientID",
                table: "Incidents",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_EmployeeID",
                table: "Incidents",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ItemID",
                table: "Incidents",
                column: "ItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
