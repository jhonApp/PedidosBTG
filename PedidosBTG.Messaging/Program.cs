using PedidosBTG.Messaging;
using System;
using System.Threading;

public class Program
{
    private static Timer pedidoTimer;
    private static Timer consumerTimer;
    private static readonly object locker = new object();

    public static void Main(string[] args)
    {
        var serviceProvider = Startup.Configure();

        pedidoTimer = new Timer(ProcessarPedidos, serviceProvider, TimeSpan.Zero, TimeSpan.FromMinutes(3)); // Executa a cada 3 minutos
        consumerTimer = new Timer(ConsumirMensagens, serviceProvider, TimeSpan.Zero, TimeSpan.FromSeconds(20)); // Executa a cada 20 segundos

        Console.ReadLine(); // Mantém o programa em execução
    }

    private static void ProcessarPedidos(object state)
    {
        lock (locker)
        {
            var serviceProvider = (IServiceProvider)state;

            using (var scope = serviceProvider.CreateScope())
            {
                var pedidoService = scope.ServiceProvider.GetRequiredService<SendPedido>();

                try
                {
                    pedidoService.SendRandomPedido();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao processar pedidos: {ex.Message}");
                }
            }
        }
    }

    private static void ConsumirMensagens(object state)
    {
        lock (locker)
        {
            var serviceProvider = (IServiceProvider)state;

            using (var scope = serviceProvider.CreateScope())
            {
                var messageConsumer = scope.ServiceProvider.GetRequiredService<ConsumerPedidos>();

                try
                {
                    messageConsumer.ConsumeMessagesFromQueue();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao consumir mensagens: {ex.Message}");
                }
            }
        }
    }
}
