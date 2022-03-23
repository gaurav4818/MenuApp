using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class newtableaddedok4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemCategories",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemCategories", x => x.categoryid);
                });
        }
    }
}
