using PedidosBTG.Core.Entity;

namespace PedidosBTG.Messaging.Interface
{
    public interface IPedidoService
    {
        int AdicionarCliente(Cliente cliente);
        int AdicionarPedido(Pedido pedido, int clienteID);
        int AdicionarItem(Item item);
        void AdicionarPedidoItem(PedidoItem pedidoItem, int itemID, int pedidoID);
    }
}
