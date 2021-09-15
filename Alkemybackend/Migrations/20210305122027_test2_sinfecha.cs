using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy_backend.Migrations
{
    public partial class test2_sinfecha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Testing2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Ubicacion = table.Column<string>(nullable: true),
                    Nombre_d = table.Column<string>(nullable: true),
                    Apellido_d = table.Column<string>(nullable: true),
                    Condicion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testing2", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testing2");
        }
    }
}
