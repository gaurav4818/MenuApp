using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class changes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemnames_itemCategories_categoryid1",
                table: "itemnames");

            migrationBuilder.RenameColumn(
                name: "categoryid1",
                table: "itemnames",
                newName: "ItemCategoryidcategoryid");

            migrationBuilder.RenameIndex(
                name: "IX_itemnames_categoryid1",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemnames_itemCategories_ItemCategoryidcategoryid",
                table: "itemnames");

            migrationBuilder.RenameColumn(
                name: "ItemCategoryidcategoryid",
                table: "itemnames",
                newName: "categoryid1");

            migrationBuilder.RenameIndex(
                name: "IX_itemnames_ItemCategoryidcategoryid",
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
    }
}
