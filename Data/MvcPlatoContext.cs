using apprest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MvcPlato.Data
{
    public class MvcPlatoContext : DbContext
    {
        public MvcPlatoContext(DbContextOptions<MvcPlatoContext>options) : base (options)
        {

        }

        public DbSet<Plato> Platos {get;set;}
    }
}