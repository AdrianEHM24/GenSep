using Microsoft.AspNetCore.Mvc;
using PruebaTecnica_API.Context;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoTrabajoController : ControllerBase
    {
        private readonly AppDbContext contextPT;

        public TurnoTrabajoController(AppDbContext context)
        {
            contextPT = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTurnoTrabajo()
        {
            return Ok(await contextPT.tblturnoTrabajo.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTurnoTrabajoXId([FromRoute] int id)
        {
            var turnoTrabajo = await contextPT.tblturnoTrabajo.FirstOrDefaultAsync(p => p.idTurno == id);

            if (turnoTrabajo == null)
            {
                return NotFound();
            }
            return Ok(turnoTrabajo);
        }
    }
}
