using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica_API.Models
{
    public class tblColaboradores
    {
        [Key]
        public int idColaborador { get; set; }
        public string? nombres { get; set; }
        public string? apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int idnivelEducativo { get; set; }
        public string? numeroCelular { get; set; }
        public bool estatus { get; set; }
        public DateTime registro { get; set; }
        public DateTime fechaIngreso { get; set; }
        public int idTurno { get; set; }
        public TimeSpan horaEntrada { get; set; }
        public TimeSpan horaSalida { get; set; }
        public decimal horasLaboradasPorDia { get; set; }
        [ForeignKey("idnivelEducativo")]
        public tblNivelEducativo? NivelesEducativos { get; set; }
        [ForeignKey("idTurno")]
        public tblTurnoTrabajo? TurnosTrabajo { get; set; }

    }
}
