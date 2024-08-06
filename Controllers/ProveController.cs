using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKAutomotriz_BE.Models;

namespace MKAutomotriz_BE.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ProveController: ControllerBase
    {
        private readonly MK_AutomotrizContext _context;

        public ProveController(MK_AutomotrizContext context)
        {
            _context = context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] Prove prove)
        {
            _context.Proves.Add(prove);
            var response = await _context.SaveChangesAsync();
            if (response <= 0)
            {
                return BadRequest("No se pudo insertar");
            }
            return Ok(true);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<Prove>> Get(int id)
        {
            var response = await _context.Proves.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Prove>>> GetAll()
        {
            return await _context.Proves.ToListAsync();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Prove prove)
        {
            var existe = await _context.Proves.AnyAsync(x => x.IdProve == prove.IdProve);
            if (!existe)
            {
                return BadRequest("Ese Prove no existe");
            }
            _context.Update(prove);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Proves.AnyAsync(x => x.IdProve == id);
            if (!existe)
            {
                return BadRequest("El Prove no existe");
            }
            _context.Remove(new Prove { IdProve = id });
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
