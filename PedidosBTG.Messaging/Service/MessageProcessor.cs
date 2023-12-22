using PedidosBTG.Messaging.Service;
using System.Text;

public class MessageProcessor
{
    private readonly IPedidoProcessor _pedidoProcessor;

    public MessageProcessor(IPedidoProcessor pedidoProcessor)
    {
        _pedidoProcessor = pedidoProcessor;
    }

    public void ProcessMessage(byte[] body)
    {
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Mensagem Recebida: " + message);

        try
        {
            _pedidoProcessor.ProcessarPedido(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao processar pedido: " + ex.Message);
        }
    }
}