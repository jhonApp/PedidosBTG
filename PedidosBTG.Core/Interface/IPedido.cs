using PedidosBTG.Core.Entity;

namespace PedidosBTG.Core.Interface
{
    public interface IPedido
    {
        void AdicionarPedido(Pedido pedido);
        List<Pedido> GetAll();
    }
}
