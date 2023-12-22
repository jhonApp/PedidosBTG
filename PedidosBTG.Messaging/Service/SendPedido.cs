using PedidosBTG.Data.Repository;

namespace PedidosBTG.Messaging
{
    public class SendPedido
    {
        public void SendRandomPedido()
        {
            var novoPedido = PedidoAleatorioGenerator.GerarPedido();
            PublishMenssager.EnviarMensagemPedido(novoPedido);
        }
    }
}
