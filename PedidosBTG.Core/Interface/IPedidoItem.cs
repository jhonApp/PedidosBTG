using PedidosBTG.Core.Entity;

namespace PedidosBTG.Core.Interface
{
    public interface IPedidoItem
    {
        void AdicionarPedidoItem(PedidoItem pedidoItem);
        List<PedidoItem> GetAll();
    }
}
