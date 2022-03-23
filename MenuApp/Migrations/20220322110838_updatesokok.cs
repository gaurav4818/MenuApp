using Microsoft.EntityFrameworkCore.Migrations;

namespace MenuApp.Migrations
{
    public partial class updatesokok : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "storeDatas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uid = table.Column<int>(type: "int", nullable: false),
                    Itemid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storeDatas", x => x.id);
                    table.ForeignKey(
                        name: "FK_storeDatas_itemnames_Itemid",
                        column: x => x.Itemid,
                        principalTable: "itemnames",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_storeDatas_Users_uid",
                        column: x => x.uid,
                        principalTable: "Users",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_storeDatas_Itemid",
                table: "storeDatas",
                column: "Itemid");

            migrationBuilder.CreateIndex(
                name: "IX_storeDatas_uid",
                table: "storeDatas",
                column: "uid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "storeDatas");
        }
    }
}
