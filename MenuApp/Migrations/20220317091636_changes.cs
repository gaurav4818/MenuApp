using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "item",
                table: "itemCategories");

            migrationBuilder.AddColumn<int>(
                name: "ItemCategorycategoryid",
                table: "itemnames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_itemnames_ItemCategorycategoryid",
                table: "itemnames",
                column: "ItemCategorycategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_itemnames_itemCategories_ItemCategorycategoryid",
                table: "itemnames",
                column: "ItemCategorycategoryid",
                principalTable: "itemCategories",
                principalColumn: "categoryid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemnames_itemCategories_ItemCategorycategoryid",
                table: "itemnames");

            migrationBuilder.DropIndex(
                name: "IX_itemnames_ItemCategorycategoryid",
                table: "itemnames");

            migrationBuilder.DropColumn(
                name: "ItemCategorycategoryid",
                table: "itemnames");

            migrationBuilder.AddColumn<string>(
                name: "item",
                table: "itemCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
