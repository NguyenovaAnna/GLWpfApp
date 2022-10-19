using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedDbSchema1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMethodEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactMethods",
                table: "ContactMethods");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "ContactMethods",
                newName: "ContactMethod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactMethod",
                table: "ContactMethod",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactMethod",
                table: "ContactMethod");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "ContactMethod",
                newName: "ContactMethods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactMethods",
                table: "ContactMethods",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ContactMethodEmployee",
                columns: table => new
                {
                    ContactMethodsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesEmployeeNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMethodEmployee", x => new { x.ContactMethodsId, x.EmployeesEmployeeNumber });
                    table.ForeignKey(
                        name: "FK_ContactMethodEmployee_ContactMethods_ContactMethodsId",
                        column: x => x.ContactMethodsId,
                        principalTable: "ContactMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactMethodEmployee_Employees_EmployeesEmployeeNumber",
                        column: x => x.EmployeesEmployeeNumber,
                        principalTable: "Employees",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactMethodEmployee_EmployeesEmployeeNumber",
                table: "ContactMethodEmployee",
                column: "EmployeesEmployeeNumber");
        }
    }
}
