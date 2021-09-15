using Alkemy_backend.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alkemy_backend.Services.Repositories
{
    public interface IAdminRepository
    {
        
        Task<IEnumerable<Usuario>> GetAdmins();
        Task<Usuario> GetAdmin(int UsuarioId);
        Task<Usuario> AddAdmin(Usuario usuario);
        Task<Usuario> UpdateAdmin(Usuario usuario);

        IActionResult LoginAdmin(Usuario usuario);
        

       /* Task<Admin> DeleteAdmin(int adminId); */
    }
}
