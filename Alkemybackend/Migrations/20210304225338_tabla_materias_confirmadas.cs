using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy_backend.Migrations
{
    public partial class tabla_materias_confirmadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MateriaConfirmada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Ubicacion = table.Column<string>(nullable: false),
                    Nombre_d = table.Column<string>(nullable: false),
                    Apellido_d = table.Column<string>(nullable: true),
                    Condicion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaConfirmada", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaConfirmada");
        }
    }
}
