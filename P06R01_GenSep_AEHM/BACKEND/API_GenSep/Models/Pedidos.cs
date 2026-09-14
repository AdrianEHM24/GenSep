using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_GenSep.Models
{
    public class Pedidos
    {
        [Key]
        public int PedidoID { get; set; }
        [ForeignKey("Clientes")]
        public int ClienteID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string? Estado { get; set; }
        public ICollection<DetallesPedido> DetallesPedidos { get; set;} = new List<DetallesPedido>();
        public Clientes? Clientes { get; set; }
    }
}
