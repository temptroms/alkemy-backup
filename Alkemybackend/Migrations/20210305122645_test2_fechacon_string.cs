using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy_backend.Migrations
{
    public partial class test2_fechacon_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Testing3",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Fecha = table.Column<string>(nullable: true),
                    Ubicacion = table.Column<string>(nullable: true),
                    Cuponmax_mat = table.Column<int>(nullable: false),
                    identificarMateria = table.Column<int>(nullable: false),
                    Dni_d = table.Column<int>(nullable: false),
                    Nombre_d = table.Column<string>(nullable: true),
                    Apellido_d = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testing3", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testing3");
        }
    }
}
