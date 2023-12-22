using PedidosBTG.Core.Entity;
using PedidosBTG.Data.Repository;
using PedidosBTG.Messaging.Interface;

namespace PedidosBTG.Messaging.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly PedidosRepository _pedidoRepository;
        private readonly ItemRepository _itemRepository;
        private readonly PedidoItemRepository _pedidoItemRepository;

        public PedidoService(ClienteRepository clienteRepository, PedidosRepository pedidoRepository, ItemRepository itemRepository, PedidoItemRepository pedidoItemRepository)
        {
            _clienteRepository = clienteRepository;
            _pedidoRepository = pedidoRepository;
            _itemRepository = itemRepository;
            _pedidoItemRepository = pedidoItemRepository;
        }

        public int AdicionarCliente(Cliente cliente)
        {
            _clienteRepository.AdicionarCliente(cliente);
            return cliente.id_cliente;
        }

        public int AdicionarPedido(Pedido pedido, int clienteID)
        {
            pedido.id_cliente = clienteID;
            _pedidoRepository.AdicionarPedido(pedido);
            return pedido.id_pedido;
        }

        public int AdicionarItem(Item item)
        {
            _itemRepository.AdicionarItem(item);
            return item.id_item;
        }

        public void AdicionarPedidoItem(PedidoItem pedidoItem, int itemID, int pedidoID)
        {
            pedidoItem.id_item = itemID;
            pedidoItem.id_pedido = pedidoID;
            _pedidoItemRepository.AdicionarPedidoItem(pedidoItem);
        }
    }
}
