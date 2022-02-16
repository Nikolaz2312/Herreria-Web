using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Herreria_web.Migrations
{
    public partial class primeraPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatDB",
                columns: table => new
                {
                    catid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDB", x => x.catid);
                });

            migrationBuilder.CreateTable(
                name: "ProDB",
                columns: table => new
                {
                    proid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rutaimg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    catid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProDB", x => x.proid);
                    table.ForeignKey(
                        name: "FK_ProDB_CatDB_catid",
                        column: x => x.catid,
                        principalTable: "CatDB",
                        principalColumn: "catid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProDB_catid",
                table: "ProDB",
                column: "catid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProDB");

            migrationBuilder.DropTable(
                name: "CatDB");
        }
    }
}
