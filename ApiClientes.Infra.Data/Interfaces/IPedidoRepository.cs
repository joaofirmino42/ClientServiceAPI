using ApiClientes.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositorio para operações de pedidos
    /// </summary>
    public interface IPedidoRepository : IBaseRepository<Pedido>
    {
        List<Pedido>ListarPedidoPorIdCliente(int idCliente);
    }
}
