using System.ComponentModel.DataAnnotations;

namespace P03R01_MC_API.Models
{
    public class Usuarios_Bd
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public int Estatus { get; set; }
        public DateTime? HorarioEntrada { get; set; }
        public DateTime? HorarioSalida { get; set; }
        public string Contrato { get; set; }
        public int Saldos { get; set; }
        public DateTime FechaIngreso { get; set; } = DateTime.Now;
        public string Telefono { get; set; }

    }//fin clase
}//fin namespace
