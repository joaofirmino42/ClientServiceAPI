using ApiClientes.Infra.Data.Entities;
using ApiClientes.Infra.Data.Contexts;
using ApiClientes.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly SqlServerContext _context;
        //construtor para injeção de dependência
        public PedidoRepository(SqlServerContext context)
        {
            _context = context;
        }
        public void Alterar(Pedido entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Pedido> Consultar()
        {
            return _context.Pedido.ToList();
        }

        public void Excluir(Pedido entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Inserir(Pedido entity)
        {

            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public List<Pedido> ListarPedidoPorIdCliente(int idCliente)
        {
            return _context.Pedido.Where(e => e.IdCliente == idCliente).ToList();
        }

        public Pedido ObterPorId(int id)
        {
            return _context.Pedido.FirstOrDefault(e => e.IdPedido.Equals(id));
        }
    }
}
