using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alkemy_backend.models
{
    public class AlkemyModel
    {

        public AlkemyModel()
        {

        }

    }


    /*
    public class Admin
    {
        public int Id { get; set; }
        public string Username_admin { get; set; }
        public string Email { get; set; } 
        public string Pass { get; set; }
        public string Rol { get; set; }
    }
    */
   
    /*
    public class Alumno
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; } 
        public string Pass { get; set; } 
        public string Rol { get; set; } 

       
    } */

    public class Materia
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        /* [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0;yyyy-MM-dd HH:mm}")] */
       /* [JsonConverter(typeof(JsonDateConverterExtension))] */
        public DateTime Fecha { get; set; }

        public string Ubicacion { get; set; }

        public int Cuponmax_mat { get; set; } // por las dudas le agregamos el bonus

        public int identificarMateria { get; set; } // agregue este field para poder llamarlo por este campo

        // DOCENTE A BUSCAR Y LLENAR
        public int Dni_d { get; set; }
        public string Nombre_d { get; set; }
        public string Apellido_d { get; set; }

        public ICollection<Materia_docente> Materia_docentes { get; set; }
    }

    public class Docente
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Activo_docente { get; set; } // entero 1 activo - 0 no activo
        public ICollection<Materia_docente> Materia_docentes { get; set; }
    }

    public class Materia_docente
    {
        public int Id { get; set; }
        public int DocenteId { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        public Docente Docente { get; set; }
    }


    //entidad para guardar 
    public class Materias_Confirmadas
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        /*  [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0;yyyy-MM-dd HH:mm}")] */
       /* [JsonConverter(typeof(JsonDateConverterExtension))]  */
        public DateTime Fecha { get; set; }

        public string Ubicacion { get; set; }

        // DOCENTE A BUSCAR Y LLENAR
        public string Nombre_d { get; set; }

        public string Apellido_d { get; set; }

        public string Condicion { get; set; }
    }

    
    public class Usuario {

        [Column("Usuario ID")]
        public int UsuarioId { get; set; }

        public string DNI { get; set; }

        [Column("Nombre Usuario")]
        public string Nombre { get; set; }

        [Column("Apellido Usuario")]
        public string Apellido { get; set; }

        [Column("Email Usuario")]
        public string Email { get; set; }

        [Column("Password Usuario")]
        public string Password { get; set; }

        [Column("Imagen Usuario")]
        public string Imagen { get; set; }

        [Column("Condicion Usuario")]
        public string Condicion { get; set; }

        [Column("Fecha Usuario")]
        public DateTime Fecha { get; set; }

        [Column("Nombre del Rol")]
        public string Rolnombre { get; set; }

        [Column("Activo - No activo")]
        public Nullable<bool> Estado { get; set; }

        public ICollection<UsuarioRol> usuarioroles { get; set; }

       /* public int rolId { get; set; } */
    }

    public class Rol {

        [DatabaseGenerated(DatabaseGeneratedOption.None), Column("Rol Id")]
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ICollection<UsuarioRol> usuarioroles { get; set; }
    }

    
    public class UsuarioRol {
        [Column("Usuario Rol ID")]
        public int UsuarioRolId { get; set; }

        [Column("Foreign user ID")]
        public int fUsuarioId { get; set; }

        [Column("Foreign Rol ID")]
        public int fRolId { get; set; }

        public Usuario usuario { get; set; }

        public Rol rol { get; set; }
    }

    public class JsonDateConverterExtension : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)

           => DateTime.ParseExact(reader.GetString(),
                  "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);


        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)

         => writer.WriteStringValue(value?.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture));
    }


}