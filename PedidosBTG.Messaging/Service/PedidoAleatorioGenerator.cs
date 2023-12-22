using PedidosBTG.Core.Entity;
using PedidosBTG.Messaging;

public class PedidoAleatorioGenerator
{
    public static Pedido GerarPedido()
    {
        var pedido = new Pedido
        {
            Cliente = ClienteAleatorioGenerator.GerarCliente(),
            PedidoItens = ItemAleatorioGenerator.CriarItensAleatorios()
        };

        return pedido;
    }
}
