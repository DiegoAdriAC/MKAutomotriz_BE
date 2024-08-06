using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKAutomotriz_BE.Models;

namespace MKAutomotriz_BE.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class RoleController: ControllerBase
    {
        private readonly  MK_AutomotrizContext _context;

        public RoleController(MK_AutomotrizContext context)
        {
            _context = context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] Role role)
        {
            _context.Roles.Add(role);
            var response = await _context.SaveChangesAsync();
            if (response <= 0)
            {
                return BadRequest("No se pudo insertar");
            }
            return Ok(true);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            var response = await _context.Roles.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Role>>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Role role)
        {
            var existe = await _context.Roles.AnyAsync(x => x.IdRole == role.IdRole);
            if (!existe)
            {
                return BadRequest("Ese Role no existe");
            }
            _context.Update(role);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Roles.AnyAsync(x => x.IdRole == id);
            if (!existe)
            {
                return BadRequest("El Role no existe");
            }
            _context.Remove(new Role { IdRole = id });
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
