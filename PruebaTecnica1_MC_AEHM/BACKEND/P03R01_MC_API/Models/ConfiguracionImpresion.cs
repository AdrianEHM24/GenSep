namespace P03R01_MC_API.Models
{
    public class ConfiguracionImpresion
    {
        public int Id { get; set; }
        public string TamanoHoja { get; set; } = "A4";
        public int TamanoFuente { get; set; } = 12;
        public string TipoFuente { get; set; } = "Arial";
        public string? ImagenFondoBase64 { get; set; }
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }
}
