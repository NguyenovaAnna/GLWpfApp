using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedDbSchema3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactMethodValue",
                table: "EmployeeContactMethod");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "EmployeeContactMethod");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactMethodValue",
                table: "ContactMethod");

            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "ContactMethod");

            migrationBuilder.AddColumn<string>(
                name: "ContactMethodValue",
                table: "EmployeeContactMethod",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "EmployeeContactMethod",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
