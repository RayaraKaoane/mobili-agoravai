using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobi_AgoraVai.Data;
using Mobi_AgoraVai.Models;

namespace Mobi_AgoraVai.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CalculadoraController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculadora>>> GetCalculadoras()
        {
            return await _context.Calculadoras.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calculadora>> GetCalculadora(int id)
        {
            var calculadora = await _context.Calculadoras.FindAsync(id);

            if (calculadora == null)
            {
                return NotFound();
            }

            return calculadora;
        }

        [HttpPost]
        public async Task<ActionResult<Calculadora>> PostCalculadora(Calculadora calculadora)
        {
            _context.Calculadoras.Add(calculadora);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCalculadora), new { id = calculadora.Id }, calculadora);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculadora(int id, Calculadora calculadora)
        {
            if (id != calculadora.Id)
            {
                return BadRequest();
            }

            _context.Entry(calculadora).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculadoraExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalculadora(int id)
        {
            var calculadora = await _context.Calculadoras.FindAsync(id);
            if (calculadora == null)
            {
                return NotFound();
            }

            _context.Calculadoras.Remove(calculadora);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalculadoraExists(int id)
        {
            return _context.Calculadoras.Any(e => e.Id == id);
        }
    }
}

