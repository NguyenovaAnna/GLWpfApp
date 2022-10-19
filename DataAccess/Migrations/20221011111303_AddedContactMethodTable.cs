using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddedContactMethodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMethods",
                columns: table => new
                {
                    ContactMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    ContactMethodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactMethodValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMethods", x => x.ContactMethodId);
                });

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
                        name: "FK_ContactMethodEmployee_ContactMethods_ContactMethodsContactMethodId",
                        column: x => x.ContactMethodsContactMethodId,
                        principalTable: "ContactMethods",
                        principalColumn: "ContactMethodId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMethodEmployee");

            migrationBuilder.DropTable(
                name: "ContactMethods");
        }
    }
}
