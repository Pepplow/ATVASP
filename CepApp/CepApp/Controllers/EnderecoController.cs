using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CepApp.Models;
using WebService.Models;

namespace CepApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly Context _context;

        public EnderecoController(Context context)
        {
            _context = context;
        }

        // GET: api/Endereco
        [HttpGet]
        public IEnumerable<CEP> GetCEP()
        {
            return _context.CEP;
        }

        // GET: api/Endereco/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCEP([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cEP = await _context.CEP.FindAsync(id);

            if (cEP == null)
            {
                return NotFound();
            }

            return Ok(cEP);
        }

        // PUT: api/Endereco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCEP([FromRoute] int id, [FromBody] CEP cEP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cEP.CepId)
            {
                return BadRequest();
            }

            _context.Entry(cEP).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CEPExists(id))
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

        // POST: api/Endereco
        [HttpPost]
        public async Task<IActionResult> PostCEP([FromBody] CEP cEP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CEP.Add(cEP);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCEP", new { id = cEP.CepId }, cEP);
        }
        
        private bool CEPExists(int id)
        {
            return _context.CEP.Any(e => e.CepId == id);
        }
    }
}