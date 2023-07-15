using Microsoft.EntityFrameworkCore;
using PoupeMais.Models;

namespace PoupeMais.Dao
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Defina as propriedades DbSet aqui
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoGasto> TipoGasto { get; set; }
        public DbSet<Recorrencia> Recorrencia { get; set; }
        public DbSet<Gastos> Gastos { get; set; }
    }
}
