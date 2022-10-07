using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalNumber = table.Column<int>(type: "int", nullable: false),
                    PreviousNumber = table.Column<int>(type: "int", nullable: false),
                    PersonellNumber = table.Column<int>(type: "int", nullable: false),
                    ActivationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeNumber);
                });

            migrationBuilder.CreateTable(
                name: "ContactMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    ContactMethodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactMethodValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactMethods_Employees_EmployeeNumber",
                        column: x => x.EmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactMethods_EmployeeNumber",
                table: "ContactMethods",
                column: "EmployeeNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMethods");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
