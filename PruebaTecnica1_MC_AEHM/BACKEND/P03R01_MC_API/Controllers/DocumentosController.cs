using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P03R01_MC_API.Context;
using P03R01_MC_API.Models;

namespace P03R01_MC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DocumentosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/documentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documento_Bd>>> GetDocumentos()
        {
            return await _context.tblDocumentos.ToListAsync();
        }

        // GET: api/documentos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Documento_Bd>> GetDocumento(int id)
        {
            var documento = await _context.tblDocumentos.FindAsync(id);
            if (documento == null) return NotFound();
            return documento;
        }

        // POST: api/documentos
        [HttpPost]
        public async Task<ActionResult<Documento_Bd>> CreateDocumento([FromBody] Documento_Bd documento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _context.tblDocumentos.AddAsync(documento);

            if (!(await _context.SaveChangesAsync() > 0))
                return StatusCode(500, "Error Interno del servidor");

            return CreatedAtAction(nameof(GetDocumento), new { id = documento.Id }, documento);
        }

        // PUT: api/documentos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocumento(int id, [FromBody] Documento_Bd documento)
        {
            if (id != documento.Id) return BadRequest();

            _context.Entry(documento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentoExists(id)) return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/documentos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumento(int id)
        {
            var documento = await _context.tblDocumentos.FindAsync(id);
            if (documento == null) return NotFound();

            _context.tblDocumentos.Remove(documento);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool DocumentoExists(int id)
        {
            return _context.tblDocumentos.Any(e => e.Id == id);
        }
    }
}
