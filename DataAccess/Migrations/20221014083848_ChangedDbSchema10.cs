using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedDbSchema10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContactMethod_Employee_EmployeeNumber",
                table: "EmployeeContactMethod");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmployeeContactMethod",
                newName: "EmployeeNumber1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContactMethod_EmployeeNumber1",
                table: "EmployeeContactMethod",
                column: "EmployeeNumber1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeContactMethod_Employee_EmployeeNumber1",
                table: "EmployeeContactMethod",
                column: "EmployeeNumber1",
                principalTable: "Employee",
                principalColumn: "EmployeeNumber",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeContactMethod_Employee_EmployeeNumber1",
                table: "EmployeeContactMethod");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeContactMethod_EmployeeNumber1",
                table: "EmployeeContactMethod");

            migrationBuilder.RenameColumn(
                name: "EmployeeNumber1",
                table: "EmployeeContactMethod",
                newName: "Id");

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
