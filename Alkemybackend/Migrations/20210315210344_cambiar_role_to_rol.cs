using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy_backend.Migrations
{
    public partial class cambiar_role_to_rol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Admin");

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Admin",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Admin");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
