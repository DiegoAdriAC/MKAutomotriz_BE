using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKAutomotriz_BE.Models;

namespace MKAutomotriz_BE.Controllers
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class CarController: ControllerBase
    {
        private readonly MK_AutomotrizContext _context;

        public CarController(MK_AutomotrizContext context)
        {
            _context = context;
        }

        [HttpPost("Insert")]
        public async Task<ActionResult> Insert([FromBody] Car car)
        {
            _context.Cars.Add(car);
            var response = await _context.SaveChangesAsync();
            if (response <= 0)
            {
                return BadRequest("No se pudo insertar");
            }
            return Ok(true);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<Car>> Get(int id)
        {
            var response = await _context.Cars.FindAsync(id);
            if (response == null)
            {
                return NotFound();
            }
            return response;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Car>>> GetAll()
        {
            return await _context.Cars.Include(x => x.Client).ToListAsync();
        }

        [HttpPut("Update")]
        public async Task<ActionResult> Update([FromBody] Car car)
        {
            var existe = await _context.Cars.AnyAsync(x => x.IdCar == car.IdCar);
            if (!existe)
            {
                return BadRequest("Ese Car no existe");
            }
            _context.Update(car);
            await _context.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await _context.Cars.AnyAsync(x => x.IdCar == id);
            if (!existe)
            {
                return BadRequest("El Car no existe");
            }
            _context.Remove(new Car { IdCar = id });
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
