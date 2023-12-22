using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosBTG.Core.Entity
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_pedido { get; set; }
        public int id_cliente { get; set; }

        [ForeignKey("id_cliente")]
        public Cliente Cliente { get; set; }
        [NotMapped] public ICollection<PedidoItem> PedidoItens { get; set; }
    }
}
