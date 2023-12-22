using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosBTG.Core.Entity
{
    [Table("Pedidoitem")]
    public class PedidoItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_pedidoitem { get; set; }
        public int id_pedido { get; set; }
        public int id_item { get; set; }
        [NotMapped] public int quantidade_total { get; set; }

        [ForeignKey("id_pedido")]
        public Pedido Pedido { get; set; }

        [ForeignKey("id_item")]
        public Item Item { get; set; }
    }
}
