using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class DropJoiningTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMethodEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMethodEmployee",
                columns: table => new
                {
                    ContactMethodsContactMethodId = table.Column<int>(type: "int", nullable: false),
                    EmployeesEmployeeNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMethodEmployee", x => new { x.ContactMethodsContactMethodId, x.EmployeesEmployeeNumber });
                    table.ForeignKey(
                        name: "FK_ContactMethodEmployee_ContactMethod_ContactMethodsContactMethodId",
                        column: x => x.ContactMethodsContactMethodId,
                        principalTable: "ContactMethod",
                        principalColumn: "ContactMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactMethodEmployee_Employee_EmployeesEmployeeNumber",
                        column: x => x.EmployeesEmployeeNumber,
                        principalTable: "Employee",
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
