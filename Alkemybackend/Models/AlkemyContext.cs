using Alkemy_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Alkemy_backend.models.AlkemyModel;

namespace Alkemy_backend.models
{
    public class AlkemyContext : DbContext
    {

        public AlkemyContext(DbContextOptions<AlkemyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {

            modelbuilder.Entity<Materia_docente>()
                .HasOne(x => x.Docente)
                .WithMany(x => x.Materia_docentes)
                .HasForeignKey(x => x.DocenteId);

            modelbuilder.Entity<Materia_docente>()
                .HasOne(x => x.Materia)
                .WithMany(x => x.Materia_docentes)
                .HasForeignKey(x => x.MateriaId);

            modelbuilder.Entity<UsuarioRol>()
                .HasOne(x => x.usuario)
                .WithMany(x => x.usuarioroles)
                .HasForeignKey(x => x.fUsuarioId);

            modelbuilder.Entity<UsuarioRol>()
                .HasOne(x => x.rol)
                .WithMany(x => x.usuarioroles)
                .HasForeignKey(x => x.fRolId);

            /* modelbuilder.Entity<Materia_docente>().HasKey(x => new { x.DocenteId, x.MateriaId }); */
            /* modelbuilder.Entity<Admin>().HasKey(x => new { x.Id});
             modelbuilder.Entity<Alumno>().HasKey(x => new { x.Id });
             modelbuilder.Entity<Materia>().HasKey(x => new { x.Id });
             modelbuilder.Entity<Docente>().HasKey(x => new { x.Id }); */

            base.OnModelCreating(modelbuilder);
        }

        /*
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Alumno> Alumno { get; set; } */
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<Rol> Rol { get; set; }
        
      
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Materia_docente> Materia_Docentes { get; set; }
        public DbSet<Docente> Docente { get; set; } 
        public DbSet<Materias_Confirmadas> MateriaConfirmada { get; set; }

    }
}
