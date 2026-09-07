using Microsoft.EntityFrameworkCore;
using Viajes_Saurio.Models;

namespace Viajes_Saurio.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { 
            
        }

        public DbSet <tblDestino> tblDestino{ get; set; }
    }
}
