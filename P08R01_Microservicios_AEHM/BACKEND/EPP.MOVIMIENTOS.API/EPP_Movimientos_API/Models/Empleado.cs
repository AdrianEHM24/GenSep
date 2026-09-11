using System.ComponentModel.DataAnnotations;

namespace EPP_Movimientos_API.Models
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }
        [Required(ErrorMessage = "El número de empleado es obligatorio.")]
        public string NumEmpleado { get; set; }
        [Required(ErrorMessage = "El nombre no puede estar vacío.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Los apellidos son requeridos.")]
        public string Apellidos { get; set; }
        public string? Departamento { get; set; }
        public string? Puesto { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }
        public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    }
}
