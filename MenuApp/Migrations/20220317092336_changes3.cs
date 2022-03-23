using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class changes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemnames_itemCategories_ItemCategoryidcategoryid",
                table: "itemnames");

            migrationBuilder.RenameColumn(
                name: "ItemCategoryidcategoryid",
                table: "itemnames",
                newName: "categoriesid");

            migrationBuilder.RenameIndex(
                name: "IX_itemnames_ItemCategoryidcategoryid",
                table: "itemnames",
                newName: "IX_itemnames_categoriesid");

            migrationBuilder.AddForeignKey(
                name: "FK_itemnames_itemCategories_catidcategoryid",
                table: "itemnames",
                column: "categoriesid",
                principalTable: "itemCategories",
                principalColumn: "categoryid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemnames_itemCategories_catidcategoryid",
                table: "itemnames");

            migrationBuilder.RenameColumn(
                name: "categoriesid",
                table: "itemnames",
                newName: "ItemCategoryidcategoryid");

            migrationBuilder.RenameIndex(
                name: "IX_itemnames_catidcategoryid",
                table: "itemnames",
                newName: "IX_itemnames_ItemCategoryidcategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_itemnames_itemCategories_ItemCategoryidcategoryid",
                table: "itemnames",
                column: "ItemCategoryidcategoryid",
                principalTable: "itemCategories",
                principalColumn: "categoryid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
