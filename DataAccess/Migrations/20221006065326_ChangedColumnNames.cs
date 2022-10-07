using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviousNumber",
                table: "Employees",
                newName: "PreviousIdNumber");

            migrationBuilder.RenameColumn(
                name: "NationalNumber",
                table: "Employees",
                newName: "NationalIdNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PreviousIdNumber",
                table: "Employees",
                newName: "PreviousNumber");

            migrationBuilder.RenameColumn(
                name: "NationalIdNumber",
                table: "Employees",
                newName: "NationalNumber");
        }
    }
}
