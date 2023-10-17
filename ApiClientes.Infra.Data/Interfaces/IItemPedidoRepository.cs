using ApiClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiClientes.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositorio para operações dos itens de pedidos
    /// </summary>
    public interface IItemPedidoRepository : IBaseRepository<ItemPedido>
    {
        List<ItemPedido> ListarItemPedidoPorIdPedido(int idPedido);
    }
}
