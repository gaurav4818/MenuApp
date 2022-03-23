using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class newtableaddedok5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuModel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Userid = table.Column<int>(type: "int", nullable: false),
                    Itemid = table.Column<int>(type: "int", nullable: false),
                    Itemnameid = table.Column<int>(type: "int", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuModel");
        }
    }
}
