// MvcIngredienteContext.cs
using Microsoft.EntityFrameworkCore;
using apprest.Models;

namespace MvcIngrediente.Data
{
    public class MvcIngredienteContext : DbContext
    {
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Plato> Platos { get; set; }

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
