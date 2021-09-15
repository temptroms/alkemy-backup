using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alkemy_backend.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Alkemy_backend.Controllers
{
   
    [Route("api/[controller]")]

    [ApiController]
    public class GestiondocenteController : ControllerBase
    {
        private readonly AlkemyContext _context;

        public GestiondocenteController(AlkemyContext context)
        {
            _context = context;
        }
        
        [HttpGet("docentes")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<IEnumerable<Docente>>> GetDocente()
        {
            return await _context.Docente.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Docente>> GetDocente(int id)
        {
            var docente = await _context.Docente.FindAsync(id);

            if (docente == null)
            {
                return NotFound();
            }

            return docente;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocente(int id, Docente docente)
        {
            if (id != docente.Id)
            {
                return BadRequest();
            }

            _context.Entry(docente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocenteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult<Docente>> PostDocente(Docente docente)
        {
            _context.Docente.Add(docente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocente", new { id = docente.Id }, docente);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Docente>> DeleteDocente(int id)
        {
            var docente = await _context.Docente.FindAsync(id);
            if (docente == null)
            {
                return NotFound();
            }

            _context.Docente.Remove(docente);
            await _context.SaveChangesAsync();

            return docente;
        }

        private bool DocenteExists(int id)
        {
            return _context.Docente.Any(e => e.Id == id);
        }
    }
}
