using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class updatesok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Itemnameid = table.Column<int>(type: "int", nullable: true),
                    Userid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_MenuModel_itemnames_Itemnameid",
                        column: x => x.Itemnameid,
                        principalTable: "itemnames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuModel_Users_Userid",
                        column: x => x.Userid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuModel_Itemnameid",
                table: "MenuModel",
                column: "Itemnameid");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModel_Userid",
                table: "MenuModel",
                column: "Userid");
        }
    }
}
