using Microsoft.EntityFrameworkCore;
using PedidosBTG.Data;
using PedidosBTG.Data.Interface;
using PedidosBTG.Data.Repository;
using PedidosBTG.Messaging.Interface;
using PedidosBTG.Messaging.Service;

namespace PedidosBTG.Messaging
{
    public class Startup
    {
        public static IServiceProvider Configure()
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            services.AddSingleton(configuration);
            services.AddSingleton(ConnectionManager.GetConnection());

            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("PedidosAWS")));

            services.AddScoped<PedidosRepository>();
            services.AddScoped<ClienteRepository>();
            services.AddScoped<ItemRepository>();
            services.AddScoped<MessageProcessor>();
            services.AddScoped<PedidoItemRepository>();
            services.AddScoped<IPedidoProcessor, PedidoProcessor>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IDbContextFactory, DbContextFactory>();
            services.AddScoped<SendPedido>();
            services.AddScoped<ConsumerPedidos>();

            return services.BuildServiceProvider();
        }
    }
}
