using Microsoft.EntityFrameworkCore;
using PruebaTecnica_API.Models;

namespace PruebaTecnica_API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }
        public DbSet<tblColaboradores> tblColaboradores { get; set; }
        public DbSet<tblNivelEducativo> tblnivelEducativo { get; set; }
        public DbSet<tblTurnoTrabajo> tblturnoTrabajo { get; set; }
    }
}
