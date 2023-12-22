using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosBTG.Core.Entity
{
    public class PedidosClienteInfo
    {
        public string ClienteID { get; set; }
        public string PedidoID { get; set; }
        public List<ItemInfo> Item { get; set; }
    }
}
