using RabbitMQ.Client;
namespace PedidosBTG.Messaging
{
    public class ConnectionManager
    {
        private static readonly object padlock = new object();
        private static ConnectionFactory factory;
        private static IConnection connection;

        public static IConnection GetConnection()
        {
            lock (padlock)
            {
                if (connection == null)
                {
                    factory = new ConnectionFactory() { HostName = "localhost" };
                    connection = factory.CreateConnection();
                }
                return connection;
            }
        }
    }
}
