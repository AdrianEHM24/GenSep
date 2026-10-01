using Microsoft.EntityFrameworkCore;
using P03R01_MC_API.Models;

namespace P03R01_MC_API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //Sirve para modificar y consultar los registros de la tabla

        public DbSet<Usuarios_Bd> tblUsuarios { get; set; }

        // Nuevas tablas
        public DbSet<Documento_Bd> tblDocumentos { get; set; }
        public DbSet<ConfiguracionImpresion> tblConfiguracionImpresion { get; set; }
    }
}
