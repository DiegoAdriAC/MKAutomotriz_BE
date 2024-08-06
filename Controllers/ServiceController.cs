using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKAutomotriz_BE.Models;

namespace MKAutomotriz_BE.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ServiceController: ControllerBase
    {
        private readonly MK_AutomotrizContext _context;

        public ServiceController(MK_AutomotrizContext context)
        {
            _context = context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] Service service)
        {
            _context.Services.Add(service);
            var response = await _context.SaveChangesAsync();
            if (response <= 0)
            {
                return BadRequest("No se pudo insertar");
            }
            return Ok(true);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<Service>> Get(int id)
        {
            var response = await _context.Services.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Service>>> GetAll()
        {
            return await _context.Services.ToListAsync();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Service service)
        {
            var existe = await _context.Services.AnyAsync(x => x.IdService == service.IdService);
            if (!existe)
            {
                return BadRequest("Ese Servicio no existe");
            }
            _context.Update(service);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Services.AnyAsync(x => x.IdService == id);
            if (!existe)
            {
                return BadRequest("El Service no existe");
            }
            _context.Remove(new Service { IdService = id });
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
