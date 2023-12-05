using apprest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MvcCliente.Data
{
    public class MvcClienteContext : DbContext
    {
        public MvcClienteContext(DbContextOptions<MvcClienteContext>options) : base (options)
        {

        }

        public DbSet<Cliente> Clientes {get;set;}
    }
}