using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKAutomotriz_BE.Models;

namespace MKAutomotriz_BE.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ClientController: ControllerBase
    {
        private readonly MK_AutomotrizContext _context;

        public ClientController(MK_AutomotrizContext context)
        {
            _context = context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] Client client)
        {
            _context.Clients.Add(client);
            var response = await _context.SaveChangesAsync();
            if (response <= 0)
            {
                return BadRequest("No se pudo insertar");
            }
            return Ok(true);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            var response = await _context.Clients.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Client>>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Client client)
        {
            var existe = await _context.Clients.AnyAsync(x => x.IdClient == client.IdClient);
            if (!existe)
            {
                return BadRequest("Ese Client no existe");
            }
            _context.Update(client);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Clients.AnyAsync(x => x.IdClient == id);
            if (!existe)
            {
                return BadRequest("El Role no existe");
            }
            _context.Remove(new Client { IdClient = id });
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
