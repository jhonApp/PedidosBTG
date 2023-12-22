using PedidosBTG.Core.Entity;

namespace PedidosBTG.Messaging
{
    public class ItemAleatorioGenerator
    {
        private static Random random = new Random();

        public static List<PedidoItem> CriarItensAleatorios()
        {
            var itens = new List<PedidoItem>();

            itens.Add(CriarItemPedido("Lápis", GerarQuantidade(), GerarPreco()));
            itens.Add(CriarItemPedido("Caderno", GerarQuantidade(), GerarPreco()));
            itens.Add(CriarItemPedido("Sabonete", GerarQuantidade(), GerarPreco()));
            itens.Add(CriarItemPedido("Refrigerante", GerarQuantidade(), GerarPreco()));

            return itens;
        }

        private static PedidoItem CriarItemPedido(string produto, int quantidade, decimal preco)
        {
            var item = new Item
            {
                produto = produto,
                quantidade = quantidade,
                preco = preco
            };

            return new PedidoItem
            {
                Item = item
            };
        }

        private static int GerarQuantidade()
        {
            return random.Next(1, 100);
        }

        private static decimal GerarPreco()
        {
            return Math.Round((decimal)(random.NextDouble() * 10), 2);
        }
    }
}
