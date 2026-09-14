using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_GenSep.Models
{
    public class Productos
    {
        [Key] 
        public int ProductoID { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Categoria { get; set; }
        [Required]
        //[Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }
        public int Stock { get; set; } = 0;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();
    }
}
