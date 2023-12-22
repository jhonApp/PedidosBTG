using Microsoft.EntityFrameworkCore;
using PedidosBTG.Core.Entity;
using PedidosBTG.Core.Interface;

namespace PedidosBTG.Data.Repository
{
    public class ItemRepository : IItem
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Item> _items;

        public ItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _items = dbContext.Set<Item>();
        }

        public void AdicionarItem(Item item)
        {
            _items.Add(item);
            _dbContext.SaveChanges();
        }

        public int GetItemID(Item item)
        {
            _dbContext.Entry(item).GetDatabaseValues();
            return item.id_item;
        }
    }

}
