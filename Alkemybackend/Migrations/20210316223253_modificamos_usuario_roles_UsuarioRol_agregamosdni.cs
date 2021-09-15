using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy_backend.Migrations
{
    public partial class modificamos_usuario_roles_UsuarioRol_agregamosdni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DNI",
                table: "Usuario");
        }
    }
}
