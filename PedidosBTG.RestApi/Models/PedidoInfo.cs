namespace PedidosBTG.API.Models
{
    public class PedidoInfo
    {
        public decimal ValorTotal { get; set; }
        public int QuantidadePedidosPorCliente { get; set; }
        public List<PedidoPorCliente> PedidosPorCliente { get; set; }
    }
}
