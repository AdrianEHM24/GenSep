using EPP_Inventario_API.Context;
using EPP_Inventario_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPP_Inventario_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _contextEPPInv;

        public ProductosController(AppDbContext context)
        {
            _contextEPPInv = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos() {
            return await _contextEPPInv.Productos.Include(p =>p.Categoria).ToListAsync();
        }

        // GET: api/productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _contextEPPInv.Productos.Include(p => p.Categoria)
                                               .FirstOrDefaultAsync(p => p.ProductoId == id);
            if (producto == null) return NotFound();
            return producto;
        }

        // POST: api/productos
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _contextEPPInv.Productos.Add(producto);
            await _contextEPPInv.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.ProductoId }, producto);
        }

        // PUT: api/productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.ProductoId) return BadRequest();
            _contextEPPInv.Entry(producto).State = EntityState.Modified;
            await _contextEPPInv.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _contextEPPInv.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            _contextEPPInv.Productos.Remove(producto);
            await _contextEPPInv.SaveChangesAsync();
            return NoContent();
        }

    }
}
