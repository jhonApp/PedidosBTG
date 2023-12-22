using Newtonsoft.Json;
using PedidosBTG.Core.Entity;
using PedidosBTG.Messaging.Interface;

namespace PedidosBTG.Messaging.Service
{
    public class PedidoProcessor : IPedidoProcessor
    {
        private readonly IPedidoService _pedidoService;

        public PedidoProcessor(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        public void ProcessarPedido(string mensagemPedido)
        {
            var pedido = JsonConvert.DeserializeObject<Pedido>(mensagemPedido);
            if (pedido == null)
            {
                throw new ArgumentException("Pedido inválido.");
            }

            int clienteID = _pedidoService.AdicionarCliente(pedido.Cliente);
            if (clienteID != 0)
            {
                int pedidoID = _pedidoService.AdicionarPedido(pedido, clienteID);
                foreach (var item in pedido.PedidoItens)
                {
                    int itemID = _pedidoService.AdicionarItem(item.Item);
                    if (itemID != 0)
                    {
                        _pedidoService.AdicionarPedidoItem(item, itemID, pedidoID);
                    }
                }
            }
        }
    }
}
