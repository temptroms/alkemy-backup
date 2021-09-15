using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Alkemy_backend.models;
using Alkemy_backend.Services.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Alkemy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AutenticarController : ControllerBase
    {

        /*private readonly IAdminRepository _adminrepository; */
        private readonly AlkemyContext _context;

      

        public AutenticarController( IAdminRepository adminrepository, AlkemyContext context)
        {
            /* _adminrepository = adminrepository; */
            _context = context;
        }

        [HttpPost("user")]
        public IActionResult Usuariologin([FromBody] Usuario usuario)
        {
            var usernombre = "";

            var login = _context.Usuario.FirstOrDefault(
                a => a.Email == usuario.Email &
                a.Password == usuario.Password
            );

            if (login == null)
            {
                return Unauthorized();
            }
            var secrettest = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("somethingyouwantwhichissecurewillworkk"));

            /* var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("4clave@secreta123")); */
            var signingCredentials = new SigningCredentials(secrettest, SecurityAlgorithms.HmacSha256);

            var roles = from ur in _context.UsuarioRol
                       join r in _context.Rol on ur.fRolId equals r.RolId
                        where r.Nombre == usuario.Rolnombre

                        select new { ur.fUsuarioId, ur.fRolId, r.Nombre };
            /* where ur.fUsuarioId == usuario.UsuarioId*/
            var username = _context.Usuario;
            foreach (var user in username)
            {
                usernombre = user.Nombre;
            }

           
            //claims para los roles
            var claims = new List<Claim>
            {
                new Claim("usernombre" as string, usernombre as string),
                
                new Claim("email", usuario.Email)

            };

            foreach (var rol in roles)
            {
                claims.Add(new Claim("role", rol.Nombre));
            }

            

            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:44325",
                audience: "https://localhost:44325", 
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signingCredentials
             );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new { Token = tokenString });
        }

    }

}