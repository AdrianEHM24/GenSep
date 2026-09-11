using System.ComponentModel.DataAnnotations;

namespace EPP_Inventario_API.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaCreacion { get; set; }
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
