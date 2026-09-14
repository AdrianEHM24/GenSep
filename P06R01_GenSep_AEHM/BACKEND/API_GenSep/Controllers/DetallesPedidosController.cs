using API_GenSep.Context;
using API_GenSep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_GenSep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallesPedidosController : ControllerBase
    {
        private readonly ILogger<DetallesPedidosController> _logger;
        private readonly AppDbContext contextGS;

        public DetallesPedidosController(ILogger<DetallesPedidosController> logger, AppDbContext appDBContext)
        {
            _logger = logger;
            contextGS = appDBContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetDetallesPedido()
        {
            try
            {
                var detallesPedido = await contextGS.DetallesPedido.ToListAsync();

                if (!detallesPedido.Any())
                    return NotFound("No se encontro ningun registro");

                return Ok(detallesPedido);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("{id:int}", Name = "GetDetallesPedidoXId")]
        public async Task<IActionResult> GetDetallesPedidoXId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invallido");

                var detallesPedido = await contextGS.DetallesPedido.FirstOrDefaultAsync(detPed => detPed.DetalleID == id);

                if (detallesPedido == null)
                    return NotFound("No existe ningun detallesPedido con ese Id");

                return Ok(detallesPedido);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("DetallesPedido-Pedido-Producto")]
        public async Task<IActionResult> GetDetallesPedidosProducto()
        {
            try
            {
                var detallesPedido = await contextGS.DetallesPedido.Include(detPed => detPed.Pedidos).Include(detPed => detPed.Productos).ToListAsync();

                if (!detallesPedido.Any())
                    return NotFound("No se encontro ningun registro");

                return Ok(detallesPedido);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("DetallesPedido-Pedido-Producto/{id:int}")]
        public async Task<IActionResult> GetDetallesPedidosProducto([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invalido");

                var detallesPedido = await contextGS.DetallesPedido.Include(detPed => detPed.Pedidos).Include(detPed => detPed.Productos).FirstOrDefaultAsync(detPed => detPed.DetalleID == id);

                if (detallesPedido == null)
                    return NotFound("No existe ningun detallesPedido con ese Id");

                return Ok(detallesPedido);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostDetallesPedido([FromBody] DetallesPedido detallesPedido)
        {
            try
            {
                if (detallesPedido == null)
                    return BadRequest("Falta Informacion");

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await contextGS.DetallesPedido.AddAsync(detallesPedido);

                if (!(await contextGS.SaveChangesAsync() > 0))
                    return StatusCode(500, "Error Interno del servidor");

                return CreatedAtRoute(nameof(GetDetallesPedidoXId), new { id = detallesPedido.DetalleID }, detallesPedido);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutDetallesPedido([FromRoute] int id, [FromBody] DetallesPedido detallesPedido)
        {
            try
            {
                if (detallesPedido == null)
                    return BadRequest("Falta informacion");

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                if (id <= 0)
                    return BadRequest("Id invalido");

                if (id != detallesPedido.DetalleID)
                    return BadRequest("El id de la ruta no coincide con el del body");

                var detallesPedidoExistente = await contextGS.DetallesPedido.FindAsync(id);

                if (detallesPedidoExistente == null)
                    return NotFound("No existe ningun detallesPedido con ese Id");

                //_dbContext.Entry(detallesPedidoExistente).CurrentValues.SetValues(detallesPedido);
                detallesPedidoExistente.PedidoID = detallesPedido.PedidoID;
                detallesPedidoExistente.ProductoID = detallesPedido.ProductoID;
                detallesPedidoExistente.Cantidad = detallesPedido.Cantidad;
                detallesPedidoExistente.PrecioUnitario = detallesPedido.PrecioUnitario;

                if (!(await contextGS.SaveChangesAsync() > 0))
                    return StatusCode(500, "Error interno del servidor");

                return Ok(detallesPedidoExistente);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDetallesPedido([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invalido");

                var detallesPedido = await contextGS.DetallesPedido.FindAsync(id);

                if (detallesPedido == null)
                    return NotFound("No existe un detallesPedido con ese ID");

                contextGS.DetallesPedido.Remove(detallesPedido);

                if (!(await contextGS.SaveChangesAsync() > 0))
                    return StatusCode(500, "Error Interno del servidor");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
