// ProyectoEvaluacion.Core/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using ProyectoEvaluacion.Models;

namespace Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<FormulaMateriales> FormulaMateriales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales: claves compuestas, relaciones, etc.
            modelBuilder.Entity<FormulaMateriales>()
                .HasKey(fm => new { fm.IdFormula, fm.Linea });
        }
    }
}
