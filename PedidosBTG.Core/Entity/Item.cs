using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosBTG.Core.Entity
{
    [Table("Item")]
    public class Item
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_item { get; set; }
        [MaxLength(100)] public string? produto { get; set; }
        public decimal quantidade { get; set; }
        public decimal preco { get; set; }
    }
}
