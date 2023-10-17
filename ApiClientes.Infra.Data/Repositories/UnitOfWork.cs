using ApiClientes.Infra.Data.Contexts;
using ApiClientes.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Repositories
{
    /// <summary>
    /// Classe para implementar a unidade de trabalho do EntityFramework
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        //atributo
        private readonly SqlServerContext _context;
        private IDbContextTransaction _transaction;
        //construtor para injeção de dependência
        public UnitOfWork(SqlServerContext context)
        {
            _context = context;
        }
        public IClienteRepository ClienteRepository => new ClienteRepository(_context);

        public IPedidoRepository PedidoRepository => new PedidoRepository(_context);

        public IItemPedidoRepository ItemPedidoRepository => new ItemPedidoRepository(_context);

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();

        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
