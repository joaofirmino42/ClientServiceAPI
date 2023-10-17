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
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly SqlServerContext _context;
        //construtor para injeção de dependência
        public ItemPedidoRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Alterar(ItemPedido entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<ItemPedido> Consultar()
        {
            return _context.ItemPedido.ToList();
        }

        public void Excluir(ItemPedido entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Inserir(ItemPedido entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public List<ItemPedido> ListarItemPedidoPorIdPedido(int idPedido)
        {
            return _context.ItemPedido.Where(e => e.IdPedido == idPedido).ToList();
        }

        public ItemPedido ObterPorId(int id)
        {
            return _context.ItemPedido.FirstOrDefault(e => e.IdItemPedido.Equals(id));
        }
    }
}
