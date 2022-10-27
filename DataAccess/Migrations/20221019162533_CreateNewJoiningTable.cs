using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class CreateNewJoiningTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactMethodValue",
                table: "ContactMethod");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "ContactMethod");

            migrationBuilder.CreateTable(
                name: "EmployeeContactMethod",
                columns: table => new
                {
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    ContactMethodId = table.Column<int>(type: "int", nullable: false),
                    ContactMethodValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContactMethod", x => new { x.EmployeeNumber, x.ContactMethodId });
                    table.ForeignKey(
                        name: "FK_EmployeeContactMethod_ContactMethod_EmployeeNumber",
                        column: x => x.EmployeeNumber,
                        principalTable: "ContactMethod",
                        principalColumn: "ContactMethodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeContactMethod_Employee_ContactMethodId",
                        column: x => x.ContactMethodId,
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

            migrationBuilder.AddColumn<string>(
                name: "ContactMethodValue",
                table: "ContactMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "ContactMethod",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
