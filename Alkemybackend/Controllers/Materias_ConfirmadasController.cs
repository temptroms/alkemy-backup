using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alkemy_backend.models;

namespace Alkemy_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Materias_ConfirmadasController : ControllerBase
    {
        private readonly AlkemyContext _context;

        public Materias_ConfirmadasController(AlkemyContext context)
        {
            _context = context;
        }

        // GET: api/Materias_Confirmadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materias_Confirmadas>>> GetMateriaConfirmada()
        {
            return await _context.MateriaConfirmada.ToListAsync();
        }

        // GET: api/Materias_Confirmadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Materias_Confirmadas>> GetMaterias_Confirmadas(int id)
        {
            var materias_Confirmadas = await _context.MateriaConfirmada.FindAsync(id);

            if (materias_Confirmadas == null)
            {
                return NotFound();
            }

            return materias_Confirmadas;
        }

        // PUT: api/Materias_Confirmadas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterias_Confirmadas(int id, Materias_Confirmadas materias_Confirmadas)
        {
            if (id != materias_Confirmadas.Id)
            {
                return BadRequest();
            }

            _context.Entry(materias_Confirmadas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Materias_ConfirmadasExists(id))
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

        // POST: api/Materias_Confirmadas

        [HttpPost("confirmacion")]
        public async Task<ActionResult<Materias_Confirmadas>> PostMaterias_Confirmadas(Materias_Confirmadas materias_Confirmadas)
        {
            _context.MateriaConfirmada.Add(materias_Confirmadas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaterias_Confirmadas", new { id = materias_Confirmadas.Id }, materias_Confirmadas);
        }

        // DELETE: api/Materias_Confirmadas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Materias_Confirmadas>> DeleteMaterias_Confirmadas(int id)
        {
            var materias_Confirmadas = await _context.MateriaConfirmada.FindAsync(id);
            if (materias_Confirmadas == null)
            {
                return NotFound();
            }

            _context.MateriaConfirmada.Remove(materias_Confirmadas);
            await _context.SaveChangesAsync();

            return materias_Confirmadas;
        }

        private bool Materias_ConfirmadasExists(int id)
        {
            return _context.MateriaConfirmada.Any(e => e.Id == id);
        }
    }
}