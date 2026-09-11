using System.ComponentModel.DataAnnotations;

namespace EPP_Inventario_API.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public string? Marca { get; set; }
        public string? Talla { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal? Precio { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Categoria Categoria { get; set; }
    }
}
