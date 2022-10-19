using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedDbSchema11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeContactMethod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeContactMethod",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    ContactMethodId = table.Column<int>(type: "int", nullable: false),
                    EmployeeNumber1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContactMethod", x => new { x.EmployeeNumber, x.ContactMethodId });
                    table.ForeignKey(
                        name: "FK_EmployeeContactMethod_ContactMethod_ContactMethodId",
                        column: x => x.ContactMethodId,
                        principalTable: "ContactMethod",
                        principalColumn: "ContactMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeContactMethod_Employee_EmployeeNumber1",
                        column: x => x.EmployeeNumber1,
                        principalTable: "Employee",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContactMethod_ContactMethodId",
                table: "EmployeeContactMethod",
                column: "ContactMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContactMethod_EmployeeNumber1",
                table: "EmployeeContactMethod",
                column: "EmployeeNumber1");
        }
    }
}
