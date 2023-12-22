using Microsoft.EntityFrameworkCore;
using PedidosBTG.Core.Entity;
using PedidosBTG.Core.Interface;

namespace PedidosBTG.Data.Repository
{
    public class PedidoItemRepository : IPedidoItem
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<PedidoItem> _pedidoItems;

        public PedidoItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _pedidoItems = dbContext.Set<PedidoItem>();
        }

        public void AdicionarPedidoItem(PedidoItem pedidoItem)
        {
            _pedidoItems.Add(pedidoItem);
            _dbContext.SaveChanges();
        }

        public List<PedidoItem> GetAll()
        {
            return _pedidoItems
                .Include(e => e.Item)
                .Include(e => e.Pedido)
                .ToList();
        }
    }

}
