using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica_API.Models
{
    public class tblNivelEducativo
    {
        [Key]
        public int idnivelEducativo { get; set; }
        public string? nivel { get; set; }
        public ICollection<tblColaboradores> Colaboradores { get; set; } = new List<tblColaboradores>();
    }
}
