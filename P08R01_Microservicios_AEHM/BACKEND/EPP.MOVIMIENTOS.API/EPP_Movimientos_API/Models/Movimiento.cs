using System.ComponentModel.DataAnnotations;

namespace EPP_Movimientos_API.Models
{
    public class Movimiento
    {
        [Key]
        public int MovimientoId { get; set; }
        [Required]
        public string? TipoMovimiento { get; set; }
        public int ProductoId { get; set; }
        [Required]
        public string? ProductoNombre { get; set; }
        public int? EmpleadoId { get; set; }
        public int Cantidad { get; set; }
        public string? Motivo { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string? RegistradoPor { get; set; }
        public Empleado? Empleado { get; set; }
    }
}
