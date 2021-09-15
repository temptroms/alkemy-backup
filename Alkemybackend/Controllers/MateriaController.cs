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
    public class MateriaController : ControllerBase
    {
        private readonly AlkemyContext _context;

        public MateriaController(AlkemyContext context)
        {
            _context = context;
        }

        [HttpGet("listamaterias")]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMateria()
        {

            return await _context.Materia.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
            var materia = await _context.Materia.FindAsync(id);

            if (materia == null)
            {
                return NotFound();
            }

            return materia;
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materia materia)
        {
            if (id != materia.Id)
            {
                return BadRequest();
            }

            _context.Entry(materia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(id))
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

      
        [HttpPost("addmateria")]
        public async Task<ActionResult<Materia>> PostMateria(Materia materia)
        {
            _context.Materia.Add(materia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMateria", new { id = materia.Id }, materia);
        }

        // DELETE: api/Materia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Materia>> DeleteMateria(int id)
        {
            var materia = await _context.Materia.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materia.Remove(materia);
            await _context.SaveChangesAsync();

            return materia;
        }

        private bool MateriaExists(int id)
        {
            return _context.Materia.Any(e => e.Id == id);
        }
    }
}
