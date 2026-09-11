using EPP_Movimientos_API.Context;
using EPP_Movimientos_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPP_Movimientos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly AppDbContext _contextEPPMov;
        public EmpleadosController(AppDbContext context)
        {
            _contextEPPMov = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpleados() {
            var empleado = await _contextEPPMov.Empleados.ToListAsync();

            if (!empleado.Any())
            {
                return NotFound("No hay registros por mostrar");
            }
            return Ok(empleado);
        }

        [HttpGet("{NumEmpleado}", Name = "GetEmpleado")]
        public async Task<IActionResult> GetEmpleado([FromRoute] string NumEmpleado) { 
            var empleado = await _contextEPPMov.Empleados.FirstOrDefaultAsync(a => a.NumEmpleado == NumEmpleado);

            if (empleado == null)
            {
                return NotFound("No existe un empleado con ese Id");
            }
            return Ok(empleado);
        }

        [HttpGet("GetEmpleadosMovimientos")]
        public async Task<IActionResult> GetEmpleadosMovimientos() { 
            var empleados = await _contextEPPMov.Empleados.Include(emp => emp.Movimientos).ToListAsync();
            
            if (!empleados.Any())
            {
                return NotFound("No hay registros para mostrar");
            }
            return Ok(empleados);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmpleado([FromBody] Empleado empleado) {
            if (empleado == null)
            {
                return BadRequest("Informacion invalida");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            await _contextEPPMov.Empleados.AddAsync(empleado);

            if (!(await _contextEPPMov.SaveChangesAsync() > 0))
            {
                return StatusCode(500, "Error interno del servidor");
            }
            return CreatedAtRoute(nameof(GetEmpleado), new { NumEmpleado = empleado.NumEmpleado }, empleado);
        }

        [HttpPut("{NumEmpleado}")]
        public async Task<IActionResult> PutEmpleado([FromRoute]string NumEmpleado, [FromBody]Empleado empleado) {
            if (empleado == null)
            {
                return BadRequest("Informacion invalida");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            if (NumEmpleado != empleado.NumEmpleado) { 
                return BadRequest("Los numeros de empleado no coinciden");
            }

            Empleado? empleadoExistente = await _contextEPPMov.Empleados.FirstOrDefaultAsync(a => a.NumEmpleado ==NumEmpleado);

            if (empleadoExistente == null)
                return NotFound("No se encontro ningun empleado con ese numero");

            //empleadoExistente.EmpleadoId = empleado.EmpleadoId;
            empleadoExistente.NumEmpleado = empleado.NumEmpleado;
            empleadoExistente.Nombre = empleado.Nombre;
            empleadoExistente.Apellidos = empleado.Apellidos;
            empleadoExistente.Departamento = empleado.Departamento;
            empleadoExistente.Puesto = empleado.Puesto;
            empleadoExistente.Activo = empleado.Activo;
            empleadoExistente.FechaAlta = empleado.FechaAlta;

            if (!(await _contextEPPMov.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return Ok(empleado);
        }

        [HttpDelete("{EmpleadoId:int}")]
        public async Task<IActionResult> DeleteEmpleado([FromRoute] int EmpleadoId) {
            if (EmpleadoId <= 0)
            {
                return BadRequest("Id invalido");
            }

            Empleado? empleadoExistente = await _contextEPPMov.Empleados.FindAsync(EmpleadoId);

            if (empleadoExistente ==null)
            {
                return NotFound("No se encontro ninguna empleado con ese Id");
            }
            _contextEPPMov.Remove(empleadoExistente);

            if (!(await _contextEPPMov.SaveChangesAsync() > 0))
            {
                return StatusCode(500, "Error Interno del servidor");
            }
            return NoContent();
        }

    }
}
