using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alkemy_backend.models;
using Alkemy_backend.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static Alkemy_backend.models.AlkemyModel;

namespace Alkemy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlkemyRestController : ControllerBase
    {


       
        /* private UserManager<Admin> _userManager;
        private SignInManager<Admin> _singInManager; */

       /* private readonly IAdminRepository _adminrepository; */

         
          /* _userManager = userManager;
           _singInManager = singInManager; */

        /* public AlkemyRestController(IAdminRepository adminrepository)
        {
            _adminrepository = adminrepository;
        }
        */

        /* Get lista de administradores  */
        /*
        [HttpGet]
        public async Task<ActionResult> GetAdmins() {
            try {
                return Ok(await _adminrepository.GetAdmins());
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error recibiendo datos de la DB");
            }
        }
        */

        /*
        [HttpGet] metodo get todas la lista de admins
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins() {

            try {
                return (await _adminrepository.GetAdmins()).ToList();
            } catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error recibiendo datos de la DB");
            }
        }
        */

        /* get lista de admin por su id */
        /*
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            try
            {
                var result = await _adminrepository.GetAdmin(id);

                if (result == null) return NotFound();


                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error recibiendo datos de la DB");
            }
        }

        /* metodo POST enviar datos a la base de datos */
        /* [HttpPost]
        public async Task<ActionResult<Admin>>

            CreateAdmin(Admin admin) {

            try {
                if (admin == null) {
                    return BadRequest();
                }

                var createdAdmin = await _adminrepository.AddAdmin(admin);
                return CreatedAtAction(nameof(GetAdmin),
                    new { id = createdAdmin.Id }, createdAdmin);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creando el nuevo admin");
            }
        } */

        /*
        [HttpPost("login")]
        public async Task<ActionResult<Admin>>

        LoginAdminAsync(Admin admin)
        {

            try
            {
                if (admin == null)
                {
                    return BadRequest();
                }

                return await _adminrepository.LoginAdmin(admin);


            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al logear admin");
            }
        }
        */

        /*
        [HttpPost("login")]
        public async Task<IActionResult> login (Admin admin){

         
            if (admin == null) {
                return BadRequest("LLego vaio o null");
            }

             Admin emailAdmin = await _userManager.FindByEmailAsync(admin.Email);
             var result = await _singInManager.PasswordSignInAsync(admin.Email, admin.PasswordHash, false, false); 
          var user = await _adminrepository.LoginAdmin(admin); 

           if (user != null) {
               
                    return Ok("resultado ok");
               

            }
           
            return BadRequest("Me dio erro prueba admin cero");
            
        }

        */

        /* actualizar */

        /*
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Admin>> UpdateAdmin(int id, Admin admin)
        {
            try
            {
                if (id != admin.Id)
                    return BadRequest("admin no se encontro");

                var adminACambiar = await _adminrepository.GetAdmin(id);

                if (adminACambiar == null)
                    return NotFound($"Admin con el Id = {id} No se encontro");

                return await _adminrepository.UpdateAdmin(admin);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }


        /*
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Admin>> DeleteAdmin(int id) {

            try {

                var adminABorrar = await _adminrepository.GetAdmin(id);

                if (adminABorrar == null)
                {
                    return NotFound($"Admin con el Id = {id} no encontrado");
                }

                return await _adminrepository.DeleteAdmin(id);
            }
            catch (Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error deleting data");
            }
        }
        */

    }
}
