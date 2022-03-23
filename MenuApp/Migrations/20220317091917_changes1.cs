using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class changes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemnames_itemCategories_ItemCategorycategoryid",
                table: "itemnames");

            migrationBuilder.DropColumn(
                name: "categoryid",
                table: "itemnames");

            migrationBuilder.RenameColumn(
                name: "ItemCategorycategoryid",
                table: "itemnames",
                newName: "categoryid1");

            migrationBuilder.RenameIndex(
                name: "IX_itemnames_ItemCategorycategoryid",
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
                newName: "ItemCategorycategoryid");

            migrationBuilder.RenameIndex(
                name: "IX_itemnames_categoryid1",
                table: "itemnames",
                newName: "IX_itemnames_ItemCategorycategoryid");

            migrationBuilder.AddColumn<int>(
                name: "categoryid",
                table: "itemnames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_itemnames_itemCategories_ItemCategorycategoryid",
                table: "itemnames",
                column: "ItemCategorycategoryid",
                principalTable: "itemCategories",
                principalColumn: "categoryid",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
