﻿// <auto-generated />
using System;
using Alkemy_backend.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alkemy_backend.Migrations
{
    [DbContext(typeof(AlkemyContext))]
    [Migration("20210316223253_modificamos_usuario_roles_UsuarioRol_agregamosdni")]
    partial class modificamos_usuario_roles_UsuarioRol_agregamosdni
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alkemy_backend.models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username_admin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Alkemy_backend.models.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Alumno");
                });

            modelBuilder.Entity("Alkemy_backend.models.Docente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Activo_docente")
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Docente");
                });

            modelBuilder.Entity("Alkemy_backend.models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido_d")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cuponmax_mat")
                        .HasColumnType("int");

                    b.Property<int>("Dni_d")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_d")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("identificarMateria")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("Alkemy_backend.models.Materia_docente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DocenteId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DocenteId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Materia_Docentes");
                });

            modelBuilder.Entity("Alkemy_backend.models.Materias_Confirmadas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido_d")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condicion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_d")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MateriaConfirmada");
                });

            modelBuilder.Entity("Alkemy_backend.models.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .HasColumnName("Rol Id")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("Alkemy_backend.models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Usuario ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnName("Apellido Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Condicion")
                        .HasColumnName("Condicion Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnName("Email Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Estado")
                        .HasColumnName("Activo - No activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnName("Fecha Usuario")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imagen")
                        .HasColumnName("Imagen Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnName("Nombre Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnName("Password Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Alkemy_backend.models.UsuarioRol", b =>
                {
                    b.Property<int>("UsuarioRolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Usuario Rol ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("fRolId")
                        .HasColumnName("Foreign Rol ID")
                        .HasColumnType("int");

                    b.Property<int>("fUsuarioId")
                        .HasColumnName("Foreign user ID")
                        .HasColumnType("int");

                    b.HasKey("UsuarioRolId");

                    b.HasIndex("fRolId");

                    b.HasIndex("fUsuarioId");

                    b.ToTable("UsuarioRol");
                });

            modelBuilder.Entity("Alkemy_backend.models.Materia_docente", b =>
                {
                    b.HasOne("Alkemy_backend.models.Docente", "Docente")
                        .WithMany("Materia_docentes")
                        .HasForeignKey("DocenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alkemy_backend.models.Materia", "Materia")
                        .WithMany("Materia_docentes")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Alkemy_backend.models.UsuarioRol", b =>
                {
                    b.HasOne("Alkemy_backend.models.Rol", "rol")
                        .WithMany("usuarioroles")
                        .HasForeignKey("fRolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alkemy_backend.models.Usuario", "usuario")
                        .WithMany("usuarioroles")
                        .HasForeignKey("fUsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
