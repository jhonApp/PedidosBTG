using Microsoft.EntityFrameworkCore;
using PedidosBTG.Core.Entity;
using PedidosBTG.Core.Interface;

namespace PedidosBTG.Data.Repository
{
    public class PedidosRepository : IPedido
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Pedido> _pedido;

        public PedidosRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _pedido = dbContext.Set<Pedido>();
        }

        public void AdicionarPedido(Pedido pedido)
        {
            _pedido.Add(pedido);
            _dbContext.SaveChanges();
        }

        public int GetPedidoID(Pedido pedido)
        {
            _dbContext.Entry(pedido).GetDatabaseValues();
            return pedido.id_pedido;
        }

        public List<Pedido> GetAll()
        {
            return _pedido
                .ToList();
        }
    }

}
