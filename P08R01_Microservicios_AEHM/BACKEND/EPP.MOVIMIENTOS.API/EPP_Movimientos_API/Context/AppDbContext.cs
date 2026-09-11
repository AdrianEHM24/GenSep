using EPP_Movimientos_API.Models;
using Microsoft.EntityFrameworkCore;

namespace EPP_Movimientos_API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
    }
}
