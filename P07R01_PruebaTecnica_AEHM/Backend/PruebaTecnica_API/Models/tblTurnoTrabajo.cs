using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica_API.Models
{
    public class tblTurnoTrabajo
    {
        [Key]
        public int idTurno { get; set; }
        public string? tipoTurno { get; set; }
        public ICollection<tblColaboradores> Colaboradores { get; set; } = new List<tblColaboradores>();
    }
}
