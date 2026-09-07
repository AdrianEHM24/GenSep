using System.ComponentModel.DataAnnotations;
using Viajes_Saurio.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Viajes_Saurio.Models
{
    public class tblDestino
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Descripcion { get; set; }

    }
}
