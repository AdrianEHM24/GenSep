using API_GenSep.Context;
using API_GenSep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_GenSep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly AppDbContext contextGS;

        public PedidosController(ILogger<PedidosController> logger, AppDbContext context)
        {
            _logger = logger;
            contextGS = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetPedidos()
        {
            try
            {
                var pedidos = await contextGS.Pedidos.ToListAsync();

                if (!pedidos.Any())
                    return NotFound("No se encontro ningun registro");

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("{id:int}", Name = "GetPedidoXId")]
        public async Task<IActionResult> GetPedidoXId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invallido");

                var pedido = await contextGS.Pedidos.FirstOrDefaultAsync(pd => pd.PedidoID == id);

                if (pedido == null)
                    return NotFound("No existe ningun pedido con ese Id");

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("Pedidos-Detalles-Cliente")]
        public async Task<IActionResult> GetPedidosPedidos()
        {
            try
            {
                var pedidos = await contextGS.Pedidos.Include(pd => pd.Clientes).Include(pd => pd.DetallesPedidos).ToListAsync();

                if (!pedidos.Any())
                    return NotFound("No se encontro ningun registro");

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("Pedidos-Detalles-Cliente/{id:int}")]
        public async Task<IActionResult> GetPedidosPedidos([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invallido");

                var pedido = await contextGS.Pedidos.Include(pd => pd.Clientes).Include(pd => pd.DetallesPedidos).FirstOrDefaultAsync(pd => pd.PedidoID == id);

                if (pedido == null)
                    return NotFound("No existe ningun pedido con ese Id");

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostPedido([FromBody] Pedidos pedido)
        {
            try
            {
                if (pedido == null)
                    return BadRequest("Falta Informacion");

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                await contextGS.Pedidos.AddAsync(pedido);

                if (!(await contextGS.SaveChangesAsync() > 0))
                    return StatusCode(500, "Error Interno del servidor");

                return CreatedAtRoute(nameof(GetPedidoXId), new { id = pedido.PedidoID }, pedido);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPedido([FromRoute] int id, [FromBody] Pedidos pedido)
        {
            try
            {
                if (pedido == null)
                    return BadRequest("Falta informacion");

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
                    return BadRequest(errors);
                }

                if (id <= 0)
                    return BadRequest("Id invalido");

                if (id != pedido.PedidoID)
                    return BadRequest("El id de la ruta no coincide con el del body");

                var pedidoExistente = await contextGS.Pedidos.FindAsync(id);

                if (pedidoExistente == null)
                    return NotFound("No existe ningun pedido con ese Id");

                //_dbContext.Entry(pedidoExistente).CurrentValues.SetValues(pedido);
                pedidoExistente.ClienteID = pedido.ClienteID;
                pedidoExistente.Fecha = pedido.Fecha;
                pedidoExistente.Total = pedido.Total;
                pedidoExistente.Estado = pedido.Estado;

                if (!(await contextGS.SaveChangesAsync() > 0))
                    return StatusCode(500, "Error interno del servidor");

                return Ok(pedidoExistente);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePedido([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invalido");

                var pedido = await contextGS.Pedidos.FindAsync(id);

                if (pedido == null)
                    return NotFound("No existe un pedido con ese ID");

                contextGS.Pedidos.Remove(pedido);

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
