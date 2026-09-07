using Microsoft.EntityFrameworkCore;
using Control_Escolar.Models;

namespace Control_Escolar.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            
        }

        public DbSet<tblAlumnos> tblAlumnos { get; set; }
    }
}
