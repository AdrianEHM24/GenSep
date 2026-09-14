using API_GenSep.Models;
using Microsoft.EntityFrameworkCore;

namespace API_GenSep.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
                    
        }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<DetallesPedido> DetallesPedido { get; set; }
    }
}
