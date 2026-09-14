using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_GenSep.Models
{
    public class DetallesPedido
    {
        [Key]
        public int DetalleID { get; set; }
        [ForeignKey("Pedidos")]
        public int PedidoID { get; set; }
        [ForeignKey("Productos")]
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Pedidos? Pedidos { get; set; }
        public Productos? Productos { get; set; }
    }
}
