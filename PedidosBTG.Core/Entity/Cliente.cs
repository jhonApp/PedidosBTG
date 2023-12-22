using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidosBTG.Core.Entity
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_cliente { get; set; }
        [MaxLength(100)] public string nome { get; set; }
    }
}
