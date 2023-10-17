using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Entities
{
    public class ItemPedido
    {
        public int IdItemPedido { get; set; }
        public string Nome { get; set; }
        public int IdPedido { get; set; }
        public decimal Valor { get; set; }
        public Pedido Pedido { get; set; }
    }
}
