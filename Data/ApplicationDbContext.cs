// ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using apprest.Models;

namespace MvcPlato.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Plato> Platos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingrediente>()
                .HasMany(ingrediente => ingrediente.Platos)
                .WithOne(plato => plato.Ingrediente)
                .HasForeignKey(plato => plato.IngredienteId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
