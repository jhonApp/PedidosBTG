using Newtonsoft.Json;
using PedidosBTG.Core.Entity;
using PedidosBTG.Data.Repository;
using PedidosBTG.Messaging.Service;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace PedidosBTG.Messaging
{
    public class ConsumerPedidos
    {
        private readonly IConnection _connection;
        private readonly PedidosRepository _pedidosRepository;
        private readonly ItemRepository _itemRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly MessageProcessor _messageProcessor;

        public ConsumerPedidos(IConnection connection, PedidosRepository pedidosRepository, ItemRepository itemRepository, ClienteRepository clienteRepository, MessageProcessor messageProcessor)
        {
            _connection = connection;
            _pedidosRepository = pedidosRepository;
            _itemRepository = itemRepository;
            _clienteRepository = clienteRepository;
            _messageProcessor = messageProcessor;
        }
        public void ConsumeMessagesFromQueue()
        {
            var connection = ConnectionManager.GetConnection();

            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "PedidosBTG", durable: false, exclusive: false, autoDelete: false, arguments: null);

                while (true)
                {
                    var result = channel.BasicGet(queue: "PedidosBTG", autoAck: true);

                    if (result != null)
                    {
                        var body = result.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine("Mensagem Recebida: " + message);

                        _messageProcessor.ProcessMessage(body);
                    }
                    else
                    {
                        // Não há mais mensagens na fila, você pode fazer algo aqui
                        break;
                    }
                }
            }
        }

        private void OnMessageReceived(object sender, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();

            _messageProcessor.ProcessMessage(body);
        }
    }
}
