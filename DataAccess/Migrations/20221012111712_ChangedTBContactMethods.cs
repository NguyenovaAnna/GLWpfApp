using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class ChangedTBContactMethods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactMethodEmployee_ContactMethods_ContactMethodsContactMethodId",
                table: "ContactMethodEmployee");

            migrationBuilder.RenameColumn(
                name: "ContactMethodId",
                table: "ContactMethods",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ContactMethodsContactMethodId",
                table: "ContactMethodEmployee",
                newName: "ContactMethodsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMethodEmployee_ContactMethods_ContactMethodsId",
                table: "ContactMethodEmployee",
                column: "ContactMethodsId",
                principalTable: "ContactMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactMethodEmployee_ContactMethods_ContactMethodsId",
                table: "ContactMethodEmployee");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ContactMethods",
                newName: "ContactMethodId");

            migrationBuilder.RenameColumn(
                name: "ContactMethodsId",
                table: "ContactMethodEmployee",
                newName: "ContactMethodsContactMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMethodEmployee_ContactMethods_ContactMethodsContactMethodId",
                table: "ContactMethodEmployee",
                column: "ContactMethodsContactMethodId",
                principalTable: "ContactMethods",
                principalColumn: "ContactMethodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
