using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alkemy_backend.Migrations
{
    public partial class modificamos_usuario_roles_UsuarioRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolId = table.Column<int>(name: "Rol Id", nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(name: "Usuario ID", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(name: "Nombre Usuario", nullable: true),
                    ApellidoUsuario = table.Column<string>(name: "Apellido Usuario", nullable: true),
                    EmailUsuario = table.Column<string>(name: "Email Usuario", nullable: true),
                    PasswordUsuario = table.Column<string>(name: "Password Usuario", nullable: true),
                    ImagenUsuario = table.Column<string>(name: "Imagen Usuario", nullable: true),
                    CondicionUsuario = table.Column<string>(name: "Condicion Usuario", nullable: true),
                    FechaUsuario = table.Column<DateTime>(name: "Fecha Usuario", nullable: false),
                    ActivoNoactivo = table.Column<bool>(name: "Activo - No activo", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRol",
                columns: table => new
                {
                    UsuarioRolID = table.Column<int>(name: "Usuario Rol ID", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForeignuserID = table.Column<int>(name: "Foreign user ID", nullable: false),
                    ForeignRolID = table.Column<int>(name: "Foreign Rol ID", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRol", x => x.UsuarioRolID);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Rol_Foreign Rol ID",
                        column: x => x.ForeignRolID,
                        principalTable: "Rol",
                        principalColumn: "Rol Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRol_Usuario_Foreign user ID",
                        column: x => x.ForeignuserID,
                        principalTable: "Usuario",
                        principalColumn: "Usuario ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_Foreign Rol ID",
                table: "UsuarioRol",
                column: "Foreign Rol ID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRol_Foreign user ID",
                table: "UsuarioRol",
                column: "Foreign user ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuarioRol");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
