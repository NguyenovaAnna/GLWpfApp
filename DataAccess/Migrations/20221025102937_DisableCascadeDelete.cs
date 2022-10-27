using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class DisableCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContactMethod_ContactMethod_ContactMethodId",
                table: "EmployeeContactMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContactMethod_Employee_EmployeeNumber",
                table: "EmployeeContactMethod");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContactMethod_ContactMethod_ContactMethodId",
                table: "EmployeeContactMethod",
                column: "ContactMethodId",
                principalTable: "ContactMethod",
                principalColumn: "ContactMethodId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContactMethod_Employee_EmployeeNumber",
                table: "EmployeeContactMethod",
                column: "EmployeeNumber",
                principalTable: "Employee",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContactMethod_ContactMethod_ContactMethodId",
                table: "EmployeeContactMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContactMethod_Employee_EmployeeNumber",
                table: "EmployeeContactMethod");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContactMethod_ContactMethod_ContactMethodId",
                table: "EmployeeContactMethod",
                column: "ContactMethodId",
                principalTable: "ContactMethod",
                principalColumn: "ContactMethodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContactMethod_Employee_EmployeeNumber",
                table: "EmployeeContactMethod",
                column: "EmployeeNumber",
                principalTable: "Employee",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
