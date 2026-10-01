using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P03R01_MC_API.Context;
using P03R01_MC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace P03R01_MC_API.Controllers
{
    //    [Route("api/[controller]")]
    //    [ApiController]
    //    public class UsuariosController : ControllerBase
    //    {
    //        private readonly AppDbContext _context;

    //        public UsuariosController(AppDbContext context)
    //        {
    //            _context = context;
    //        }

    //        // POST: api/auth/login
    //        [HttpPost("login")]
    //        public async Task<ActionResult<Usuarios_Bd>> Login([FromBody] LoginRequest request)
    //        {
    //            var usuario = await _context.tblUsuarios
    //                .FirstOrDefaultAsync(u => u.NombreUsuario == request.NombreUsuario && u.Pass == request.Pass);

    //            if (usuario == null)
    //                return Unauthorized(new { message = "Credenciales inválidas" });

    //            // Devolvemos el usuario sin la contraseña por seguridad básica
    //            return Ok(new
    //            {
    //                usuario.Id,
    //                usuario.NombreUsuario,
    //                usuario.Nombre,
    //                usuario.Rol,
    //                usuario.Estatus
    //            });
    //        }

    //        // POST: api/auth/agregarUsuario
    //        [HttpPost("agregarUsuario")]
    //        public async Task<ActionResult<Usuarios_Bd>> AgregarUsuario([FromBody] Usuarios_Bd usuario_bd)
    //        {
    //            if (!ModelState.IsValid)
    //            {
    //                var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
    //                return BadRequest(errors);
    //            }

    //            await _context.tblUsuarios.AddAsync(usuario_bd);

    //            if (!(await _context.SaveChangesAsync() > 0))
    //                return StatusCode(500, "Error Interno del servidor");

    //            return Created();
    //        }

    //        // GET: api/auth/usuarios (Lista todos)
    //        [HttpGet("usuarios")]
    //        public async Task<ActionResult<IEnumerable<Usuarios_Bd>>> GetUsuarios()
    //        {
    //            return await _context.tblUsuarios.ToListAsync();
    //        }

    //        // GET: api/auth/usuarios/{id}
    //        [HttpGet("usuarios/{id}")]
    //        public async Task<ActionResult<Usuarios_Bd>> GetUsuario(int id)
    //        {
    //            var usuario = await _context.tblUsuarios.FindAsync(id);
    //            if (usuario == null) return NotFound();
    //            return usuario;
    //        }

    //        // PUT: api/auth/usuarios/{id}
    //        [HttpPut("usuarios/{id}")]
    //        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuarios_Bd usuario)
    //        {
    //            if (id != usuario.Id) return BadRequest();

    //            _context.Entry(usuario).State = EntityState.Modified;

    //            try
    //            {
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!UsuarioExists(id)) return NotFound();
    //                throw;
    //            }

    //            return NoContent();
    //        }

    //        // DELETE: api/auth/usuarios/{id}
    //        [HttpDelete("{id}")]
    //        public async Task<IActionResult> DeleteUsuario(int id)
    //        {
    //            var usuario = await _context.tblUsuarios.FindAsync(id);
    //            if (usuario == null) return NotFound();
    //            _context.tblUsuarios.Remove(usuario);
    //            await _context.SaveChangesAsync();
    //            return NoContent();
    //        }

    //        private bool UsuarioExists(int id)
    //        {
    //            return _context.tblUsuarios.Any(e => e.Id == id);
    //        }


    //}//fin clase

    //public class LoginRequest
    //{
    //    public string NombreUsuario { get; set; }
    //    public string Pass { get; set; }
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/usuarios/login
        [HttpPost("login")]
        public async Task<ActionResult<Usuarios_Bd>> Login([FromBody] LoginRequest request)
        {
            var usuario = await _context.tblUsuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == request.NombreUsuario && u.Pass == request.Pass);

            // Credenciales incorrectas → 401
            if (usuario == null)
                return Unauthorized(new { message = "Credenciales inválidas" });

            // Estatus 0  dado de baja
            if (usuario.Estatus == 0)
            {
                return Ok(new
                {
                    usuario.Id,
                    usuario.NombreUsuario,
                    usuario.Nombre,
                    usuario.Rol,
                    usuario.Estatus,
                    requiereCambioPassword = false,
                    message = "Usuario dado de baja. Contacte al administrador."
                });
            }

            // Estatus 2  requiere cambio de contraseña
            if (usuario.Estatus == 2)
            {
                return Ok(new
                {
                    usuario.Id,
                    usuario.NombreUsuario,
                    usuario.Nombre,
                    usuario.Rol,
                    usuario.Estatus,
                    requiereCambioPassword = true,
                    message = "Debe cambiar su contraseña antes de continuar."
                });
            }

            // Validación de horario (solo si tiene horario definido)
            if (usuario.HorarioEntrada.HasValue && usuario.HorarioSalida.HasValue)
            {
                var horaActual = DateTime.Now.TimeOfDay;
                var horaEntrada = usuario.HorarioEntrada.Value.TimeOfDay;
                var horaSalida = usuario.HorarioSalida.Value.TimeOfDay;

                // Validar si está fuera del horario
                if (horaActual < horaEntrada || horaActual > horaSalida)
                {
                    return Ok(new
                    {
                        usuario.Id,
                        usuario.NombreUsuario,
                        usuario.Nombre,
                        usuario.Rol,
                        usuario.Estatus,
                        requiereCambioPassword = false,
                        message = $"Acceso denegado. Su horario laboral es de " +
                                  $"{horaEntrada:hh\\:mm} a {horaSalida:hh\\:mm}. " +
                                  $"Hora actual: {DateTime.Now:HH:mm}."
                    });
                }
            }

            // Estatus 1 + horario permitido = login exitoso
            return Ok(new
            {
                usuario.Id,
                usuario.NombreUsuario,
                usuario.Nombre,
                usuario.Rol,
                usuario.Estatus,
                requiereCambioPassword = false
            });
        }

        //        // POST: api/usuarios/agregarUsuario
        //[HttpPost("agregarUsuario")]
        //public async Task<ActionResult<Usuarios_Bd>> AgregarUsuario([FromBody] Usuarios_Bd usuario_bd)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
        //        return BadRequest(errors);
        //    }

        //    // 🔒 Asignar estatus según el rol
        //    usuario_bd.Estatus = usuario_bd.Rol == "Administrador" ? 1 : 2;

        //    // 📅 Inicializar fechas si no vienen
        //    if (usuario_bd.FechaCreacion == default(DateTime) || usuario_bd.FechaCreacion.Year < 1753)
        //        usuario_bd.FechaCreacion = DateTime.Now;

        //    if (usuario_bd.FechaIngreso == default(DateTime) || usuario_bd.FechaIngreso.Year < 1753)
        //        usuario_bd.FechaIngreso = DateTime.Now;

        //    // 📅 Inicializar horarios si no vienen (opcional)
        //    if (usuario_bd.HorarioEntrada.HasValue && usuario_bd.HorarioEntrada.Value.Year < 1753)
        //        usuario_bd.HorarioEntrada = null;

        //    if (usuario_bd.HorarioSalida.HasValue && usuario_bd.HorarioSalida.Value.Year < 1753)
        //        usuario_bd.HorarioSalida = null;

        //    await _context.tblUsuarios.AddAsync(usuario_bd);

        //    if (!(await _context.SaveChangesAsync() > 0))
        //        return StatusCode(500, "Error Interno del servidor");

        //    return Created();
        //}

        // POST: api/usuarios/agregarUsuario
        [HttpPost("agregarUsuario")]
        public async Task<ActionResult<Usuarios_Bd>> AgregarUsuario([FromBody] Usuarios_Bd usuario_bd)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(err => err.Errors).Select(err => err.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            // 🔒 Asignar estatus según el rol
            usuario_bd.Estatus = usuario_bd.Rol == "Administrador" ? 1 : 2;

            // 📅 Inicializar fechas si no vienen
            if (usuario_bd.FechaCreacion == default(DateTime) || usuario_bd.FechaCreacion.Year < 1753)
                usuario_bd.FechaCreacion = DateTime.Now;

            if (usuario_bd.FechaIngreso == default(DateTime) || usuario_bd.FechaIngreso.Year < 1753)
                usuario_bd.FechaIngreso = DateTime.Now;

            // 📅 Inicializar horarios si no vienen (opcional)
            if (usuario_bd.HorarioEntrada.HasValue && usuario_bd.HorarioEntrada.Value.Year < 1753)
                usuario_bd.HorarioEntrada = null;

            if (usuario_bd.HorarioSalida.HasValue && usuario_bd.HorarioSalida.Value.Year < 1753)
                usuario_bd.HorarioSalida = null;

            await _context.tblUsuarios.AddAsync(usuario_bd);

            if (!(await _context.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return Created();
        }
        // GET: api/usuarios/usuarios (TODOS, incluyendo inactivos)
        [HttpGet("usuarios")]
        public async Task<ActionResult<IEnumerable<Usuarios_Bd>>> GetUsuarios()
        {
            return await _context.tblUsuarios.ToListAsync();
        }

        // GET: api/usuarios/activos (solo estatus = 1)
        [HttpGet("activos")]
        public async Task<ActionResult<IEnumerable<Usuarios_Bd>>> GetUsuariosActivos()
        {
            return await _context.tblUsuarios
                .Where(u => u.Estatus == 1)
                .ToListAsync();
        }

        // GET: api/usuarios/usuarios/{id}
        [HttpGet("usuarios/{id}")]
        public async Task<ActionResult<Usuarios_Bd>> GetUsuario(int id)
        {
            var usuario = await _context.tblUsuarios.FindAsync(id);
            if (usuario == null) return NotFound();
            return usuario;
        }

        // PUT: api/usuarios/usuarios/{id}
        [HttpPut("usuarios/{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuarios_Bd usuario)
        {
            if (id != usuario.Id) return BadRequest(new { message = "El ID no coincide." });

            var usuarioExistente = await _context.tblUsuarios.FindAsync(id);
            if (usuarioExistente == null) return NotFound(new { message = "Usuario no encontrado." });

            // Actualizar todos los campos editables
            usuarioExistente.NombreUsuario = usuario.NombreUsuario;
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Rol = usuario.Rol;
            usuarioExistente.Estatus = usuario.Estatus;
            usuarioExistente.HorarioEntrada = usuario.HorarioEntrada;
            usuarioExistente.HorarioSalida = usuario.HorarioSalida;
            usuarioExistente.Contrato = usuario.Contrato;
            usuarioExistente.Saldos = usuario.Saldos;
            usuarioExistente.FechaIngreso = usuario.FechaIngreso;
            usuarioExistente.Telefono = usuario.Telefono;

            // Solo actualizar la contraseña si viene con valor
            if (!string.IsNullOrWhiteSpace(usuario.Pass))
            {
                usuarioExistente.Pass = usuario.Pass;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }
        // DELETE: api/usuarios/{id} → Borrado lógico (Estatus = 0)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.tblUsuarios.FindAsync(id);
            if (usuario == null) return NotFound();

            // Si ya está dado de baja
            if (usuario.Estatus == 0)
                return BadRequest(new { message = "El usuario ya está dado de baja." });

            // Borrado lógico
            usuario.Estatus = 0;
            _context.tblUsuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/usuarios/{id}/cambiarPassword → Cambio de contraseña
        [HttpPatch("{id}/cambiarPassword")]
        public async Task<IActionResult> CambiarPassword(int id, [FromBody] CambioPasswordRequest request)
        {
            var usuario = await _context.tblUsuarios.FindAsync(id);
            if (usuario == null) return NotFound(new { message = "Usuario no encontrado." });

            if (usuario.Estatus == 0)
                return BadRequest(new { message = "El usuario está dado de baja." });

            // Validar que la nueva contraseña no esté vacía
            if (string.IsNullOrWhiteSpace(request.NuevaPassword))
                return BadRequest(new { message = "La nueva contraseña no puede estar vacía." });

            // Actualizar contraseña y estatus a activo (1)
            usuario.Pass = request.NuevaPassword;
            usuario.Estatus = 1;

            _context.tblUsuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/usuarios/{id}/reactivar → Reactivar usuario (Estatus 1)
        [HttpPatch("{id}/reactivar")]
        public async Task<IActionResult> ReactivarUsuario(int id)
        {
            var usuario = await _context.tblUsuarios.FindAsync(id);
            if (usuario == null) return NotFound(new { message = "Usuario no encontrado." });

            if (usuario.Estatus == 1)
                return BadRequest(new { message = "El usuario ya está activo." });

            usuario.Estatus = 1;
            _context.tblUsuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.tblUsuarios.Any(e => e.Id == id);
        }
    }

    public class LoginRequest
    {
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
    }

    // 📌 DTO para el cambio de contraseña
    public class CambioPasswordRequest
    {
        public string NuevaPassword { get; set; }
    }

}//fin namespace
