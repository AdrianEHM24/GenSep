using Control_Escolar.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Control_Escolar.Models
{
    public class tblAlumnos
    {
        [Key]
        public int Matricula { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Apellido_Paterno { get; set; }
        public string? Apellido_Materno { get; set; }
        public string? Correo { get; set; }
        public int Telefono { get; set; }
    }
}
