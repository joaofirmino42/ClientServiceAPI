using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Entities
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int NumeroPedido { get; set; }
        public DateTime DataCriacao { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemPedido> ItemPedido { get; set; }
    }
}
