using P03R01_MC_API.Models;

namespace P03R01_MC_API.Services
{
    public interface IPdfService
    {
        byte[] GenerarPdfIndividual(int documentoId);
        byte[] GenerarZipLote(List<int> documentoIds);
    }
}
