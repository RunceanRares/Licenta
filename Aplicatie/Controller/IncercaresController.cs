using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aplicatie.Model;
using Aplicatie.Models;



namespace Aplicatie.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncercaresController : ControllerBase
    {
        private readonly AplicatieContext _context;

        public IncercaresController(AplicatieContext context)
        {
            _context = context;
        }

        // GET: api/Incercares
        [HttpGet]
        public IEnumerable<Incercare> GetIncercare()
        {
            return _context.Incercare;
        }

        // GET: api/Incercares/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncercare([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var incercare = await _context.Incercare.FindAsync(id);

            if (incercare == null)
            {
                return NotFound();
            }

            return Ok(incercare);
        }

        // PUT: api/Incercares/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncercare([FromRoute] int id, [FromBody] Incercare incercare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incercare.ID)
            {
                return BadRequest();
            }

            _context.Entry(incercare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncercareExists(id))
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

        // POST: api/Incercares
        [HttpPost]
        public async Task<IActionResult> PostIncercare([FromBody] Incercare incercare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Incercare.Add(incercare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncercare", new { id = incercare.ID }, incercare);
        }

        // DELETE: api/Incercares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncercare([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var incercare = await _context.Incercare.FindAsync(id);
            if (incercare == null)
            {
                return NotFound();
            }

            _context.Incercare.Remove(incercare);
            await _context.SaveChangesAsync();

            return Ok(incercare);
        }

        private bool IncercareExists(int id)
        {
            return _context.Incercare.Any(e => e.ID == id);
        }
    }
}