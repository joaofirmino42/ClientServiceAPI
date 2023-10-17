using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de unidade de trabalho do EntityFramework
    /// </summary>
    public interface IUnitOfWork
    {
        #region Métodos para controle de transação
        void BeginTransaction();
        void Commit();
        void Rollback();
        #endregion
        #region Métodos para acesso aos repositórios
       
        public IClienteRepository ClienteRepository { get; }
        public IPedidoRepository PedidoRepository { get; }
        public IItemPedidoRepository ItemPedidoRepository { get; }
        #endregion
    }
}
