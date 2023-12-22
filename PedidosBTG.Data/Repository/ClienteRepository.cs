using Microsoft.EntityFrameworkCore;
using PedidosBTG.Core.Entity;
using PedidosBTG.Core.Interface;

namespace PedidosBTG.Data.Repository
{
    public class ClienteRepository : ICliente
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Cliente> _clientes;

        public ClienteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _clientes = dbContext.Set<Cliente>();
        }

        public void AdicionarCliente(Cliente cliente)
        {
            _clientes.Add(cliente);
            _dbContext.SaveChanges();
        }

        public int GetClienteID(Cliente cliente)
        {
            _dbContext.Entry(cliente).GetDatabaseValues();
            return cliente.id_cliente;
        }
    }
}