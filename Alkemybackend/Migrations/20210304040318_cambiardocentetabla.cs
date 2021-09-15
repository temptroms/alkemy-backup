using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy_backend.Migrations
{
    public partial class cambiardocentetabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido_d",
                table: "Materia",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dni_d",
                table: "Materia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre_d",
                table: "Materia",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido_d",
                table: "Materia");

            migrationBuilder.DropColumn(
                name: "Dni_d",
                table: "Materia");

            migrationBuilder.DropColumn(
                name: "Nombre_d",
                table: "Materia");
        }
    }
}
