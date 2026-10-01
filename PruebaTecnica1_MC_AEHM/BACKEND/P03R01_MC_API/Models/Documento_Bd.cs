namespace P03R01_MC_API.Models
{
    public class Documento_Bd
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Contrato { get; set; }
        public int? Saldos { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string? Telefono { get; set; }
    }
}
