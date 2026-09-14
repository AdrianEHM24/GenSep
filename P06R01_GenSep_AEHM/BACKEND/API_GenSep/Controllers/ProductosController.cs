using API_GenSep.Context;
using API_GenSep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_GenSep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext contextGS;

        public ProductosController(AppDbContext context) { 
            contextGS = context;
        }

        //[HttpGet]
        //public ActionResult Get() {
        //    return Ok(contextGS.Productos.ToList());
        //}
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            return Ok(await contextGS.Productos.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductoXId([FromRoute]int id) { 
            var Producto = await contextGS.Productos.FirstOrDefaultAsync(p => p.ProductoID == id);

            if (Producto == null)
            {
                return NotFound();
            }
            return Ok(Producto);
        }

        [HttpGet("ProductosDetallesPed")]
        public async Task<IActionResult> GetProductosDetallesPed()
        {
            return Ok(await contextGS.Productos.Include(c => c.DetallesPedidos).ToListAsync());
        }

        [HttpGet("ByIdProdDP/{id:int}")]
        public async Task<IActionResult> GetProductosDetPedXId([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var productos = await contextGS.Productos.Include(c => c.DetallesPedidos).FirstOrDefaultAsync(p => p.ProductoID == id);

            if (productos == null)
                return NotFound("No existe ningun cliente con ese Id");

            return Ok(productos);
        }

        [HttpPost]
        public async Task<IActionResult> PostProducto([FromBody] Productos Productos)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await contextGS.Productos.AddAsync(Productos);

            if (!(await contextGS.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return Created();
        }
        //public ActionResult Post([FromBody]Productos Productos) {
        //    try
        //    {
        //        contextGS.Productos.Add(Productos);
        //        contextGS.SaveChanges();
        //        return Ok(Productos);
        //    }
        //    catch (Exception ex) {
        //        Console.WriteLine(ex.Message);
        //        return BadRequest(ex.ToString());

        //    }
        //}


        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutProducto([FromRoute] int id, [FromBody] Productos productos)
        {
            if (productos == null)
                return BadRequest("Falta información");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            if (id <= 0)
                return BadRequest("Id invalido");

            if (id != productos.ProductoID)
                return BadRequest("El id de la ruta no coincide con el del body");

            var productoExistente = await contextGS.Productos.FindAsync(id);

            if (productoExistente == null)
                return NotFound("No existe ningun cliente con ese Id");

            //_dbContext.Entry(clienteExistente).CurrentValues.SetValues(cliente);
            productoExistente.Nombre = productos.Nombre;
            productoExistente.Categoria = productos.Categoria;
            productoExistente.Precio = productos.Precio;
            productoExistente.Stock = productos.Stock;
            productoExistente.FechaCreacion = productos.FechaCreacion;

            if (!(await contextGS.SaveChangesAsync() > 0))
                return StatusCode(500, "Error interno del servidor");

            return Ok(productoExistente);
        }
        //public ActionResult Put(int id, [FromBody]Productos Productos) {
        //    if (id != Productos.ProductoID)
        //    {
        //        return NotFound();
        //    }
        //    contextGS.Entry(Productos).State = EntityState.Modified;
        //    contextGS.SaveChanges();
        //    return Ok();
        //}

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProducto([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id invalido");

            var producto = await contextGS.Productos.FindAsync(id);

            if (producto == null)
                return NotFound("No existe un cliente con ese ID");

            contextGS.Productos.Remove(producto);

            if (!(await contextGS.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return NoContent();
        }
        //public ActionResult Delete([FromRoute] int id)
        //{
        //    var Producto = contextGS.Productos.FirstOrDefault(a => a.ProductoID == id);
        //    if (Producto == null)
        //    {
        //        return NotFound();
        //    }
        //    contextGS.Productos.Remove(Producto);
        //    contextGS.SaveChanges();
        //    return Ok();
        //}
    }
}
