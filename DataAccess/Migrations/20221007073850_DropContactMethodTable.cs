using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class DropContactMethodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactMethods_Employees_EmployeeNumber",
                table: "ContactMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactMethods",
                table: "ContactMethods");

            migrationBuilder.RenameTable(
                name: "ContactMethods",
                newName: "ContactMethod");

            migrationBuilder.RenameIndex(
                name: "IX_ContactMethods_EmployeeNumber",
                table: "ContactMethod",
                newName: "IX_ContactMethod_EmployeeNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactMethod",
                table: "ContactMethod",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMethod_Employees_EmployeeNumber",
                table: "ContactMethod",
                column: "EmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactMethod_Employees_EmployeeNumber",
                table: "ContactMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactMethod",
                table: "ContactMethod");

            migrationBuilder.RenameTable(
                name: "ContactMethod",
                newName: "ContactMethods");

            migrationBuilder.RenameIndex(
                name: "IX_ContactMethod_EmployeeNumber",
                table: "ContactMethods",
                newName: "IX_ContactMethods_EmployeeNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactMethods",
                table: "ContactMethods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMethods_Employees_EmployeeNumber",
                table: "ContactMethods",
                column: "EmployeeNumber",
                principalTable: "Employees",
                principalColumn: "EmployeeNumber");
        }
    }
}
