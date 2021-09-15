using Alkemy_backend.models;
using Alkemy_backend.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Alkemy_backend.Models
{

    
    public class AdminRepository : IAdminRepository
    {
        private readonly AlkemyContext _context;

        public AdminRepository(AlkemyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuario() {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetAdmin(int usuarioid) {
            return await _context.Usuario.FirstOrDefaultAsync(a => a.UsuarioId == usuarioid);
        }

        public async Task<Usuario> AddUser(Usuario usuario) {
            var result = await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync(); 
            return result.Entity;
        }

       
       public IActionResult LoginUser(Usuario usuario) {
            
               var login = _context.Usuario.FirstOrDefault(
                   a => a.Email == usuario.Email &
                   a.Password == usuario.Password
               );

               if (login == null)
               {
                   return null;
               }
               else {
                   var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("clave@secreta123"));
                   var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                   var tokenOptions = new JwtSecurityToken(

                       issuer: "https://localhost:9055",
                       audience: "https://localhost:9055",
                       claims: new List<Claim>(),
                       expires: DateTime.Now.AddMinutes(3),
                       signingCredentials: signingCredentials
                    );

                   var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                   return OkResult();
               }
            
        }

        private IActionResult OkResult()
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> UpdateAdmin(Usuario usuario) {
            var result = await _context.Usuario.FirstOrDefaultAsync(a => a.UsuarioId == usuario.UsuarioId);

            if (result != null) {
                result.Nombre = usuario.Nombre;
                result.Email = usuario.Email;
                result.Password = usuario.Password;

                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        } 

       public async void DeleteUsuario(int usuarioid) {

            var result = await _context.Usuario.FirstOrDefaultAsync(a => a.UsuarioId == usuarioid);

            if (result != null) {
                _context.Usuario.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Usuario>> GetAdmins()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> AddAdmin(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public IActionResult LoginAdmin(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }

}