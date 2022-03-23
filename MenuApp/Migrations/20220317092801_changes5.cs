using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class changes5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemnames_itemCategories_catidcategoryid",
                table: "itemnames");

            migrationBuilder.RenameColumn(
                name: "catidcategoryid",
                table: "itemnames",
                newName: "categoryid1");

            migrationBuilder.RenameIndex(
                name: "IX_itemnames_catidcategoryid",
                table: "itemnames",
                newName: "IX_itemnames_categoryid1");

            migrationBuilder.AddForeignKey(
                name: "FK_itemnames_itemCategories_categoryid1",
                table: "itemnames",
                column: "categoryid1",
                principalTable: "itemCategories",
                principalColumn: "categoryid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemnames_itemCategories_categoryid1",
                table: "itemnames");

            migrationBuilder.RenameColumn(
                name: "categoryid1",
                table: "itemnames",
                newName: "catidcategoryid");

            migrationBuilder.RenameIndex(
                name: "IX_itemnames_categoryid1",
                table: "itemnames",
                newName: "IX_itemnames_catidcategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_itemnames_itemCategories_catidcategoryid",
                table: "itemnames",
                column: "catidcategoryid",
                principalTable: "itemCategories",
                principalColumn: "categoryid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
