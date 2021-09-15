using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Alkemy_backend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoInfoController : ControllerBase
    {
      [HttpGet]
      /* [Authorize(Roles = "Administrador")] */
      public IEnumerable<string> AdminGet() => new string[] { "admin", "admin" };


      [HttpGet("alumnoi")]
      /* [Authorize(Roles = "Alumno")] */
      public IEnumerable<string> AlumnoGet() => new string[] { "alumno", "solo apto para alumnos" };
    }
 
}
