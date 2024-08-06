using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKAutomotriz_BE.Models;

namespace MKAutomotriz_BE.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class UserController: ControllerBase
    {
        private readonly MK_AutomotrizContext _context;

        public UserController(MK_AutomotrizContext context)
        {
            _context = context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] User user)
        {
            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();
            if (result <= 0)
            {
                return BadRequest(result);
            }
            return Ok(true);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var response = await _context.Users.FindAsync(id);
            if (response == null)
            {
                return BadRequest("El Usuario No existe");
            }
            return response;

        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return await _context.Users.Include(x => x.Role).ToListAsync();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] User user)
        {
            var existe = await _context.Users.AnyAsync(x => x.IdUser == user.RoleId);
            if (!existe)
            {
                return BadRequest("El Usuario no existe");
            }
            _context.Update(user);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Users.AnyAsync(x => x.IdUser == id);
            if (!existe)
            {
                return BadRequest("El Usuario no existe");
            }
            _context.Remove(new User { IdUser = id });
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
