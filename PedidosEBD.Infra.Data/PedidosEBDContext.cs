using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Pedidos.Domain.Models;

namespace PedidosEBD.Infra.Data
{
    public class PedidosEBDContext : DbContext
    {
        public PedidosEBDContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Congregacao> Congregacoes { get; set; }
        public DbSet<Usuario> Usuarios {get; set;}
    }
}
