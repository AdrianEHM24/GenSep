using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_API.Context;
using PruebaTecnica_API.Models;
using System.Data;

namespace PruebaTecnica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly AppDbContext contextPT;
        private readonly ILogger<ColaboradoresController> _logger;
        private readonly string _connectionString;

        public ColaboradoresController(ILogger<ColaboradoresController> logger, AppDbContext context, IConfiguration configuration)
        {
            contextPT = context;
            _logger = logger;
            _connectionString = configuration.GetConnectionString("Conexion");
        }
        [HttpGet]
        public async Task<IActionResult> GetColaboradores()
        {
            try
            {
                var colaboradores = await contextPT.tblColaboradores.Where(col => col.estatus).ToListAsync();

                if (!colaboradores.Any())
                    return NotFound("No se encontro ningun registro");

                return Ok(colaboradores);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("{id:int}", Name = "GetColaboradorXId")]
        public async Task<IActionResult> GetColaboradorXId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invalido");

                var colaborador = await contextPT.tblColaboradores.FirstOrDefaultAsync(c => c.idColaborador == id && c.estatus);

                if (colaborador == null)
                    return NotFound("No existe ningun colaborador con ese Id");

                return Ok(colaborador);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("Colaboradores-Relaciones")]
        public async Task<IActionResult> GetColaboradoresRelaciones()
        {
            try
            {
                var colaboradores = await contextPT.tblColaboradores
                    .Include(c => c.NivelesEducativos)
                    .Include(c => c.TurnosTrabajo).Take(10).Where(c => c.estatus)
                    .ToListAsync();

                if (!colaboradores.Any())
                    return NotFound("No se encontro ningun registro");

                return Ok(colaboradores);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("Colaboradores-Relaciones/{id:int}")]
        public async Task<IActionResult> GetColaboradorRelacionesXId([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invalido");

                var colaborador = await contextPT.tblColaboradores
                    .Include(c => c.NivelesEducativos)
                    .Include(c => c.TurnosTrabajo)
                    .FirstOrDefaultAsync(c => c.idColaborador == id && c.estatus);

                if (colaborador == null)
                    return NotFound("No existe ningun colaborador con ese Id");

                return Ok(colaborador);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("Consultar-FechaTurno")]
        public async Task<IActionResult> GetColaboradoresFechaTurno([FromQuery] DateTime? fechaInicio, [FromQuery] DateTime? fechaFin, [FromQuery] int? idTurno)
        {
            try
            {
                var parameters = new[]
                {
                new SqlParameter("@FechaInicio", (object)fechaInicio ?? DBNull.Value),
                new SqlParameter("@FechaFin", (object)fechaFin ?? DBNull.Value),
                new SqlParameter("@idTurno", (object)idTurno ?? DBNull.Value)
            };

                //FromSqlRaw se usa si el sp devuelve filas, las mapea a la entidad indicada
                var colaboradores = await contextPT.tblColaboradores
                    .FromSqlRaw("EXEC spConsultar_FechaTurno_Colaboradores @FechaInicio, @FechaFin, @idTurno", parameters)
                    .ToListAsync();

                if (!colaboradores.Any())
                    return NotFound("No se encontro ningun registro");

                return Ok(colaboradores);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpGet("InfoGeneral-FechaHora")]
        public async Task<IActionResult> GetInfoGeneralFechaHora([FromQuery] DateTime? fechaInicio, [FromQuery] DateTime? fechaFin, [FromQuery] TimeSpan? horaInicio, [FromQuery] TimeSpan? horaFin)
        {
            try
            {
                if ((fechaInicio == null || fechaFin == null) && (horaInicio == null || horaFin == null))
                    return BadRequest("Debes mandar por lo menos un tipo de filtro");

                // SqlConnection se usa cuando el sp no devuelve filas mapeables a alguna aentidad
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("spConsultar_FechaHora_Colaboradores", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaInicio", (object)fechaInicio ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaFin", (object)fechaFin ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@horaInicio", (object)horaInicio ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@horaFin", (object)horaFin ?? DBNull.Value);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                var resultado = new
                                {
                                    TotalColaboradores = reader.GetInt32(0),
                                    TotalTurnoMatutino = reader.IsDBNull(1) ? 0 : reader.GetDecimal(1),
                                    TotalTurnoVespertino = reader.IsDBNull(2) ? 0 : reader.GetDecimal(2),
                                    TotalTurnoNocturno = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3)
                                };

                                return Ok(resultado);
                            }
                        }
                    }
                }

                return NotFound("No se encontro ningun registro");
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostColaborador([FromBody] tblColaboradores colaborador)
        {
            try
            {
                if (colaborador == null)
                    return BadRequest("Falta Informacion");

                var errores = ValidarColaborador(colaborador);
                if (errores.Any())
                    return BadRequest(errores);

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsert_Colaboradores", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@nombres", colaborador.nombres);
                        cmd.Parameters.AddWithValue("@apellidoPaterno", colaborador.apellidoPaterno);
                        cmd.Parameters.AddWithValue("@apellidoMaterno", colaborador.apellidoMaterno);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", colaborador.fechaNacimiento);
                        cmd.Parameters.AddWithValue("@idnivelEducativo", colaborador.idnivelEducativo);
                        cmd.Parameters.AddWithValue("@numeroCelular", colaborador.numeroCelular);
                        cmd.Parameters.AddWithValue("@estatus", colaborador.estatus);
                        cmd.Parameters.AddWithValue("@registro", DateTime.Now);
                        cmd.Parameters.AddWithValue("@fechaIngreso", colaborador.fechaIngreso);
                        cmd.Parameters.AddWithValue("@idTurno", colaborador.idTurno);
                        cmd.Parameters.AddWithValue("@horaEntrada", colaborador.horaEntrada);
                        cmd.Parameters.AddWithValue("@horaSalida", colaborador.horaSalida);
                        cmd.Parameters.AddWithValue("@horasLaboradasPorDia", colaborador.horasLaboradasPorDia);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutColaborador([FromRoute] int id, [FromBody] tblColaboradores colaborador)
        {
            try
            {
                if (colaborador == null)
                    return BadRequest("Falta informacion");

                if (id <= 0)
                    return BadRequest("Id invalido");

                if (id != colaborador.idColaborador)
                    return BadRequest("El id de la ruta no coincide con el del body");

                var errores = ValidarColaborador(colaborador);
                if (errores.Any())
                    return BadRequest(errores);

                var existente = await contextPT.tblColaboradores.FindAsync(id);

                if (existente == null)
                    return NotFound("No existe ningun colaborador con ese Id");

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spUpdate_Colaboradores", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idColaborador", id);
                        cmd.Parameters.AddWithValue("@nombres", colaborador.nombres);
                        cmd.Parameters.AddWithValue("@apellidoPaterno", colaborador.apellidoPaterno);
                        cmd.Parameters.AddWithValue("@apellidoMaterno", colaborador.apellidoMaterno);
                        cmd.Parameters.AddWithValue("@fechaNacimiento", colaborador.fechaNacimiento);
                        cmd.Parameters.AddWithValue("@idnivelEducativo", colaborador.idnivelEducativo);
                        cmd.Parameters.AddWithValue("@numeroCelular", colaborador.numeroCelular);
                        cmd.Parameters.AddWithValue("@estatus", colaborador.estatus);
                        cmd.Parameters.AddWithValue("@registro", DateTime.Now);
                        cmd.Parameters.AddWithValue("@fechaIngreso", colaborador.fechaIngreso);
                        cmd.Parameters.AddWithValue("@idTurno", colaborador.idTurno);
                        cmd.Parameters.AddWithValue("@horaEntrada", colaborador.horaEntrada);
                        cmd.Parameters.AddWithValue("@horaSalida", colaborador.horaSalida);
                        cmd.Parameters.AddWithValue("@horasLaboradasPorDia", colaborador.horasLaboradasPorDia);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                return Ok(colaborador);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteColaborador([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Id invalido");

                var existente = await contextPT.tblColaboradores.FindAsync(id);

                if (existente == null)
                    return NotFound("No existe un colaborador con ese ID");

                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spEliminarColaborador", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idColaborador", id);

                        await conn.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrio un error Inesperado: " + ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }

        private List<string> ValidarColaborador(tblColaboradores c)
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(c.nombres) || c.nombres.Length < 2 || c.nombres.Length > 60 || !c.nombres.All(ch => char.IsLetter(ch) || ch == ' '))
                errores.Add("El nombre debe tener solo letras y espacios, entre 2 y 60 caracteres");

            if (string.IsNullOrWhiteSpace(c.apellidoPaterno) || c.apellidoPaterno.Length < 2 || c.apellidoPaterno.Length > 60 || !c.apellidoPaterno.All(ch => char.IsLetter(ch) || ch == ' '))
                errores.Add("El apellido paterno debe tener solo letras y espacios, entre 2 y 60 caracteres");

            if (string.IsNullOrWhiteSpace(c.apellidoMaterno) || c.apellidoMaterno.Length < 2 || c.apellidoMaterno.Length > 60 || !c.apellidoMaterno.All(ch => char.IsLetter(ch) || ch == ' '))
                errores.Add("El apellido materno debe tener solo letras y espacios, entre 2 y 60 caracteres");

            if (c.fechaNacimiento == default(DateTime))
                errores.Add("La fecha de nacimiento es requerida");
            else
            {
                var edad = DateTime.Today.Year - c.fechaNacimiento.Year;
                if (c.fechaNacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;
                if (edad < 18)
                    errores.Add("El colaborador debe ser mayor de 18 años");
            }

            if (c.idnivelEducativo <= 0)
                errores.Add("El nivel educativo es requerido");

            if (string.IsNullOrWhiteSpace(c.numeroCelular) || c.numeroCelular.Length != 10 || !c.numeroCelular.All(char.IsDigit))
                errores.Add("El numero de celular debe tener exactamente 10 digitos numericos");

            if (c.fechaIngreso == default(DateTime))
                errores.Add("La fecha de ingreso es requerida");
            else if (c.fechaIngreso > DateTime.Today)
                errores.Add("La fecha de ingreso no puede ser mayor a la fecha actual");

            if (c.idTurno <= 0)
                errores.Add("El turno es requerido");

            if (c.horaEntrada == default(TimeSpan))
                errores.Add("La hora de entrada es requerida");

            if (c.horaSalida == default(TimeSpan))
                errores.Add("La hora de salida es requerida");

            if (c.idTurno > 0 && c.horaEntrada != default(TimeSpan) && c.horaSalida != default(TimeSpan))
            {
                if (c.idTurno == 1 && (c.horaEntrada < new TimeSpan(8, 0, 0) || c.horaSalida > new TimeSpan(14, 0, 0)))
                    errores.Add("El turno Matutino debe estar entre 08:00 y 14:00");

                if (c.idTurno == 2 && (c.horaEntrada < new TimeSpan(14, 0, 0) || c.horaSalida > new TimeSpan(20, 0, 0)))
                    errores.Add("El turno Vespertino debe estar entre 14:00 y 20:00");

                if (c.idTurno == 3 && !(c.horaEntrada >= new TimeSpan(20, 0, 0) || c.horaSalida <= new TimeSpan(2, 0, 0)))
                    errores.Add("El turno Nocturno debe estar entre 20:00 y 02:00");

                if (c.idTurno != 3 && c.horaSalida <= c.horaEntrada)
                    errores.Add("La hora de salida debe ser mayor a la hora de entrada");
            }

            return errores;
        }
    }
}
