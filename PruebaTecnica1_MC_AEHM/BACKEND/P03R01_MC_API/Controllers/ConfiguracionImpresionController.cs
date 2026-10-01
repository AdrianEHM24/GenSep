using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P03R01_MC_API.Context;
using P03R01_MC_API.Models;

namespace P03R01_MC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionImpresionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ConfiguracionImpresionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/configuracionimpresion
        [HttpGet]
        public async Task<ActionResult<ConfiguracionImpresion>> GetConfiguracion()
        {
            var config = await _context.tblConfiguracionImpresion.FirstOrDefaultAsync();
            if (config == null) return NotFound();
            return config;
        }

        // PUT: api/configuracionimpresion
        [HttpPut]
        public async Task<IActionResult> UpdateConfiguracion([FromBody] ConfiguracionImpresion config)
        {
            var existente = await _context.tblConfiguracionImpresion.FirstOrDefaultAsync();

            if (existente == null)
            {
                config.FechaActualizacion = DateTime.Now;
                await _context.tblConfiguracionImpresion.AddAsync(config);
            }
            else
            {
                existente.TamanoHoja = config.TamanoHoja;
                existente.TamanoFuente = config.TamanoFuente;
                existente.TipoFuente = config.TipoFuente;
                existente.ImagenFondoBase64 = config.ImagenFondoBase64;
                existente.FechaActualizacion = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
