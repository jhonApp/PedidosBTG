using Microsoft.EntityFrameworkCore;
using PedidosBTG.Data.Interface;

namespace PedidosBTG.Data
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IConfiguration _configuration;

        public DbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PedidosAWS"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
