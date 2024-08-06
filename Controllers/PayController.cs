using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKAutomotriz_BE.Models;

namespace MKAutomotriz_BE.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class PayController: ControllerBase
    {
        private readonly MK_AutomotrizContext _context;

        public PayController(MK_AutomotrizContext context)
        {
            _context = context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] Pay pay)
        {
            _context.Pays.Add(pay);
            var response = await _context.SaveChangesAsync();
            if (response <= 0)
            {
                return BadRequest("No se pudo insertar");
            }
            return Ok(true);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<Pay>> Get(int id)
        {
            var response = await _context.Pays.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Pay>>> GetAll()
        {
            return await _context.Pays.ToListAsync();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Pay pay)
        {
            var existe = await _context.Pays.AnyAsync(x => x.IdPay == pay.IdPay);
            if (!existe)
            {
                return BadRequest("Ese Pay no existe");
            }
            _context.Update(pay);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Pays.AnyAsync(x => x.IdPay == id);
            if (!existe)
            {
                return BadRequest("El Pay no existe");
            }
            _context.Remove(new Pay { IdPay = id });
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
