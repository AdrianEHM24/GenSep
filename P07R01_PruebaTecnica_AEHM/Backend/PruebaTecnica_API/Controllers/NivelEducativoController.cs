using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_API.Context;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_API.Models;

namespace PruebaTecnica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NivelEducativoController : ControllerBase
    {
        private readonly AppDbContext contextPT;

        public NivelEducativoController(AppDbContext context)
        {
            contextPT = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetNivelEducativo()
        {
            return Ok(await contextPT.tblnivelEducativo.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetNivelEducativoXId([FromRoute] int id)
        {
            var nivelEducativo = await contextPT.tblnivelEducativo.FirstOrDefaultAsync(p => p.idnivelEducativo == id);

            if (nivelEducativo == null)
            {
                return NotFound();
            }
            return Ok(nivelEducativo);
        }

        //[HttpPost]
        //public async Task<IActionResult> PostNivelEducativo([FromBody] tblNivelEducativo nivelEducativo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
        //        return BadRequest(errors);
        //    }

        //    await contextPT.tblnivelEducativo.AddAsync(nivelEducativo);

        //    if (!(await contextPT.SaveChangesAsync() > 0))
        //        return StatusCode(500, "Error Interno del servidor");

        //    return Created();
        //}

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> PutProducto([FromRoute] int id, [FromBody] Productos productos)
        //{
        //    if (productos == null)
        //        return BadRequest("Falta información");

        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
        //        return BadRequest(errors);
        //    }

        //    if (id <= 0)
        //        return BadRequest("Id invalido");

        //    if (id != productos.ProductoID)
        //        return BadRequest("El id de la ruta no coincide con el del body");

        //    var productoExistente = await contextGS.Productos.FindAsync(id);

        //    if (productoExistente == null)
        //        return NotFound("No existe ningun cliente con ese Id");

        //    //_dbContext.Entry(clienteExistente).CurrentValues.SetValues(cliente);
        //    productoExistente.Nombre = productos.Nombre;
        //    productoExistente.Categoria = productos.Categoria;
        //    productoExistente.Precio = productos.Precio;
        //    productoExistente.Stock = productos.Stock;
        //    productoExistente.FechaCreacion = productos.FechaCreacion;

        //    if (!(await contextGS.SaveChangesAsync() > 0))
        //        return StatusCode(500, "Error interno del servidor");

        //    return Ok(productoExistente);
        //}

        //[HttpDelete("{id:int}")]
        //public async Task<IActionResult> DeleteProducto([FromRoute] int id)
        //{
        //    if (id <= 0)
        //        return BadRequest("Id invalido");

        //    var producto = await contextGS.Productos.FindAsync(id);

        //    if (producto == null)
        //        return NotFound("No existe un cliente con ese ID");

        //    contextGS.Productos.Remove(producto);

        //    if (!(await contextGS.SaveChangesAsync() > 0))
        //        return StatusCode(500, "Error Interno del servidor");

        //    return NoContent();
        //}
    }
}
