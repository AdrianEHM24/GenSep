using EPP_Movimientos_API.Context;
using EPP_Movimientos_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPP_Movimientos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly AppDbContext _contextEPPMov;
        public MovimientosController(AppDbContext context)
        {
            _contextEPPMov = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimiento>>> GetMovimientos()
        {
            return await _contextEPPMov.Movimientos.Include(p => p.Empleado).ToListAsync();
        }

        // GET: api/productos/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Movimiento>> GetMovimiento([FromRoute]int id)
        {
            try
            {
                Console.WriteLine($"El id es: {id}");
                var producto = await _contextEPPMov.Movimientos.Include(p=> p.Empleado)
                                                   .FirstOrDefaultAsync(p => p.MovimientoId == id);
                if (producto == null)
                {
                    return NotFound();
                }
                return producto;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }
        }

        // POST: api/productos
        [HttpPost]
        public async Task<ActionResult<Movimiento>> PostMovimiento(Movimiento movimiento)
        {
            _contextEPPMov.Movimientos.Add(movimiento);
            await _contextEPPMov.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovimiento), new { id = movimiento.MovimientoId }, movimiento);
        }

        // PUT: api/productos/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutMovimiento([FromRoute]int id, Movimiento movimiento)
        {
            if (id != movimiento.MovimientoId) return BadRequest();
            _contextEPPMov.Entry(movimiento).State = EntityState.Modified;
            await _contextEPPMov.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/productos/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProducto([FromRoute]int id)
        {
            var producto = await _contextEPPMov.Movimientos.FindAsync(id);
            if (producto == null) return NotFound();
            _contextEPPMov.Movimientos.Remove(producto);
            await _contextEPPMov.SaveChangesAsync();
            return NoContent();
        }
    }
}
