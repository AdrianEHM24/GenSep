using Microsoft.AspNetCore.Mvc;
using P03R01_MC_API.Services;

namespace P03R01_MC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        // POST: api/pdf/generar/{id}
        [HttpPost("generar/{id}")]
        public IActionResult GenerarPdfIndividual(int id)
        {
            try
            {
                var pdfBytes = _pdfService.GenerarPdfIndividual(id);
                return File(pdfBytes, "application/pdf", $"documento_{id}.pdf");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/pdf/generar-lote
        [HttpPost("generar-lote")]
        public IActionResult GenerarPdfLote([FromBody] LoteRequest request)
        {
            try
            {
                if (request.DocumentoIds == null || !request.DocumentoIds.Any())
                    return BadRequest(new { message = "Debe seleccionar al menos un documento." });

                var zipBytes = _pdfService.GenerarZipLote(request.DocumentoIds);
                return File(zipBytes, "application/zip", "documentos.zip");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }//Fin clase

    // DTO para la petición de lote
    public class LoteRequest
    {
        public List<int> DocumentoIds { get; set; } = new();
    }

}//Fin namespace
