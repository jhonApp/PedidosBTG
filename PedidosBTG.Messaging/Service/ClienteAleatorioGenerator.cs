using PedidosBTG.Core.Entity;

namespace PedidosBTG.Messaging
{
    public class ClienteAleatorioGenerator
    {
        private static Random random = new Random();

        private static List<string> nomes = new List<string>
        {
            "João", "Maria", "Pedro", "Ana", "Luiza", "Carlos", "Mariana", "Fernando", "Julia"
        };

        private static List<string> sobrenomes = new List<string>
        {
            "Silva", "Santos", "Oliveira", "Pereira", "Lima", "Costa", "Ferreira", "Rodrigues"
        };

        public static Cliente GerarCliente()
        {
            string nomeCompleto = GerarNomeAleatorio();

            return new Cliente
            {
                nome = nomeCompleto
            };
        }

        private static string GerarNomeAleatorio()
        {
            string nomeAleatorio = nomes[random.Next(nomes.Count)];
            string sobrenomeAleatorio = sobrenomes[random.Next(sobrenomes.Count)];

            return $"{nomeAleatorio} {sobrenomeAleatorio}";
        }
    }
}
