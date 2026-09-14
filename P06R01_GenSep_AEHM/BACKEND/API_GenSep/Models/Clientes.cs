using System.ComponentModel.DataAnnotations;

namespace API_GenSep.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }
        [Required(ErrorMessage = "El Nombre es Requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El email es Requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El Telefono es Requerido")]
        public string Telefono { get; set; }
        public ICollection<Pedidos> Pedidos { get; set; } = new List<Pedidos>();
    }
}
