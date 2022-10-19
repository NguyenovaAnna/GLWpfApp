using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedDbSchema6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeContactMethod");

            migrationBuilder.DropColumn(
                name: "ContactMethodValue",
                table: "ContactMethod");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "ContactMethod");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ContactMethod",
                newName: "ContactMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactMethodId",
                table: "ContactMethod",
                newName: "Id");

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
                        name: "FK_EmployeeContactMethod_ContactMethod_EmployeeNumber",
                        column: x => x.EmployeeNumber,
                        principalTable: "ContactMethod",
                        principalColumn: "Id",
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
    }
}
