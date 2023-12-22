namespace PedidosBTG.Data.Interface
{
    public interface IDbContextFactory
    {
        AppDbContext CreateDbContext();
    }
}
