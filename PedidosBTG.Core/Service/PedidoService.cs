using PedidosBTG.Core.Entity;
using PedidosBTG.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBTG.Core.Service
{
    public class PedidoService
    {
        private readonly IPedidoItem _pedidoItem;
        private readonly IPedido _pedido;

        public PedidoService(IPedidoItem pedidoItem, IPedido pedido)
        {
            _pedidoItem = pedidoItem;
            _pedido = pedido;
        }

        public List<PedidoInfo> ObterValorTotalPedido()
        {
            List<PedidoItem> pedidoItems = _pedidoItem.GetAll();

            // Agrupar os pedidos por ID
            var pedidosAgrupados = pedidoItems
                .GroupBy(item => item.id_pedido)
                .Select(group => new PedidoInfo
                {
                    PedidoID = $"{group.Key}",
                    ValorTotal = group.Sum(item => item.Item.preco * item.Item.quantidade).ToString("C2")
                })
                .ToList();

            return pedidosAgrupados;
        }

        public List<QuantidadeInfo> QuantidadePedidos()
        {
            List<Pedido> pedidos = _pedido.GetAll();

            // Agrupar os pedidos por ID
            var pedidosAgrupados = pedidos
                .GroupBy(item => item.id_cliente)
                .Select(group => new QuantidadeInfo
                {
                    ClienteID = $"{group.Key}",
                    Quantidade = group.Count()
                })
                .ToList();

            return pedidosAgrupados;
        }

        public List<PedidosClienteInfo> PedidosPorCliente()
        {
            List<Pedido> pedidos = _pedido.GetAll();
            List<PedidoItem> pedidoItems = _pedidoItem.GetAll();

            var pedidosAgrupados = pedidos
                .GroupBy(item => item.id_cliente)
                .Select(group => new PedidosClienteInfo
                {
                    ClienteID = $"{group.Key}",
                    Item = pedidoItems
                        .Where(pi => pedidos.Any(p => p.id_pedido == pi.id_pedido && p.id_cliente == group.Key))
                        .Select(pi => new ItemInfo
                        {
                            Item = pi.Item
                        })
                        .ToList()
                })
                .ToList();

            return pedidosAgrupados;
        }




    }
}
