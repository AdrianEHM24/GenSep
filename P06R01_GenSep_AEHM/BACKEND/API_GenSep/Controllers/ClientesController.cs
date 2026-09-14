using API_GenSep.Context;
using API_GenSep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_GenSep.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext contextGS;

        public ClientesController(AppDbContext context)
        {
            contextGS = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            return Ok(await contextGS.Clientes.ToListAsync());
        }

        [HttpGet("ById/{id:int}")]
        public async Task<IActionResult> GetClienteXId([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var cliente = await contextGS.Clientes.FirstOrDefaultAsync(clnt => clnt.ClienteID == id);

            if (cliente == null)
                return NotFound("No existe ningun cliente con ese Id");

            return Ok(cliente);
        }
        [HttpGet("ClientesPedidos")]
        public async Task<IActionResult> GetClientesPedidos()
        {
            return Ok(await contextGS.Clientes.Include(c => c.Pedidos).ToListAsync());
        }

        [HttpGet("ByIdCP/{id:int}")]
        public async Task<IActionResult> GetClientesPedidosXId([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id inválido");

            var cliente = await contextGS.Clientes.Include(c => c.Pedidos).FirstOrDefaultAsync(clnt => clnt.ClienteID == id);

            if (cliente == null)
                return NotFound("No existe ningun cliente con ese Id");

            return Ok(cliente);
        }


        [HttpPost]
        public async Task<IActionResult> PostCliente([FromBody] Clientes cliente)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await contextGS.Clientes.AddAsync(cliente);

            if (!(await contextGS.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return Created();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutCliente([FromRoute] int id, [FromBody]Clientes cliente)
        {
            if (cliente == null)
                return BadRequest("Falta información");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            if (id <= 0)
                return BadRequest("Id invalido");

            if (id != cliente.ClienteID)
                return BadRequest("El id de la ruta no coincide con el del body");

            var clienteExistente = await contextGS.Clientes.FindAsync(id);

            if (clienteExistente == null)
                return NotFound("No existe ningun cliente con ese Id");

            //_dbContext.Entry(clienteExistente).CurrentValues.SetValues(cliente);
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefono = cliente.Telefono;

            if (!(await contextGS.SaveChangesAsync() > 0))
                return StatusCode(500, "Error interno del servidor");

            return Ok(clienteExistente);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] int id)
        {
            if (id <= 0)
                return BadRequest("Id invalido");

            var cliente = await contextGS.Clientes.FindAsync(id);

            if (cliente == null)
                return NotFound("No existe un cliente con ese ID");

            contextGS.Clientes.Remove(cliente);

            if (!(await contextGS.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return NoContent();
        }

    }
}
