using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedDbSchema9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeContactMethod",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    ContactMethodId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_EmployeeContactMethod_Employee_EmployeeNumber",
                        column: x => x.EmployeeNumber,
                        principalTable: "Employee",
                        principalColumn: "EmployeeNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContactMethod_ContactMethodId",
                table: "EmployeeContactMethod",
                column: "ContactMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeContactMethod");
        }
    }
}
