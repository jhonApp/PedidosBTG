using Microsoft.EntityFrameworkCore;
using PedidosBTG.Core.Entity;

namespace PedidosBTG.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }


}
