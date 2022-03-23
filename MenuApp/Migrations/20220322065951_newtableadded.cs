using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class newtableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_itemnames_itemCategories_categoryid1",
                table: "itemnames");

            migrationBuilder.DropIndex(
                name: "IX_itemnames_categoryid1",
                table: "itemnames");

            migrationBuilder.DropColumn(
                name: "categoryid1",
                table: "itemnames");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "categoryid1",
                table: "itemnames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_itemnames_categoryid1",
                table: "itemnames",
                column: "categoryid1");

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
